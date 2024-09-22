using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    public class ImageProcessor
    {
        private static readonly object lockObject = new object();
        private static readonly Mutex mutex = new Mutex();

        private static readonly SemaphoreSlim
            semaphore = new SemaphoreSlim(4); // Ограничиваем до 4 параллельных потоков

        public static Bitmap ApplyBlur(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            int blurSize = 5;

            Parallel.For(0, image.Width, x =>
            {
                semaphore.Wait();
                try
                {
                    // Создаем локальную копию исходного изображения для каждого потока
                    Bitmap localImage = (Bitmap)image.Clone();

                    for (int y = 0; y < localImage.Height; y++)
                    {
                        int avgR = 0, avgG = 0, avgB = 0;
                        int blurPixelCount = 0;

                        for (int xx = x; xx < x + blurSize && xx < localImage.Width; xx++)
                        {
                            for (int yy = y; yy < y + blurSize && yy < localImage.Height; yy++)
                            {
                                Color pixel = localImage.GetPixel(xx, yy);

                                lock (lockObject)
                                {
                                    avgR += pixel.R;
                                    avgG += pixel.G;
                                    avgB += pixel.B;
                                }

                                blurPixelCount++;
                            }
                        }

                        avgR /= blurPixelCount;
                        avgG /= blurPixelCount;
                        avgB /= blurPixelCount;

                        lock (lockObject)
                        {
                            result.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                        }
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            });

            return result;
        }

        public static Bitmap AdjustBrightness(Bitmap image, int brightness)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            Parallel.For(0, image.Width, x =>
            {
                // Создаем локальную копию исходного изображения для каждого потока
                Bitmap localImage = (Bitmap)image.Clone();

                mutex.WaitOne();
                try
                {
                    for (int y = 0; y < localImage.Height; y++)
                    {
                        Color pixel = localImage.GetPixel(x, y);

                        int r = pixel.R + brightness;
                        int g = pixel.G + brightness;
                        int b = pixel.B + brightness;

                        r = Math.Max(Math.Min(255, r), 0);
                        g = Math.Max(Math.Min(255, g), 0);
                        b = Math.Max(Math.Min(255, b), 0);

                        result.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            });

            return result;
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Выберите фильтр для применения к изображению:");
        Console.WriteLine("1. Blur");
        Console.WriteLine("2. Brightness");

        string choice = Console.ReadLine();
        Bitmap image = new Bitmap("sample.jpg"); // Укажите путь к вашему изображению
        Bitmap result = null;

        switch (choice)
        {
            case "1":
                Console.WriteLine("Применяем фильтр Blur...");
                result = ImageProcessor.ApplyBlur(image);
                break;
            case "2":
                Console.WriteLine("Введите значение яркости (-255 до 255):");
                int brightness = int.Parse(Console.ReadLine());
                Console.WriteLine("Применяем фильтр Brightness...");
                result = ImageProcessor.AdjustBrightness(image, brightness);
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        // Сохраняем результат
        string outputFilePath = "result.jpg";
        result.Save(outputFilePath, ImageFormat.Jpeg);
        Console.WriteLine($"Результат сохранен в {outputFilePath}");
    }
}