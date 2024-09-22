using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

public class ImageProcessor
{
    // Используем lock для защиты общего ресурса
    private static readonly object lockObject = new object();
    private static readonly Mutex mutex = new Mutex();
    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(4); // Ограничиваем до 4 параллельных потоков

    public static Bitmap ApplyBlur(Bitmap image)
    {
        Bitmap result = new Bitmap(image.Width, image.Height);
        int blurSize = 5;

        Parallel.For(0, image.Width, x =>
        {
            semaphore.Wait();
            try
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    for (int xx = x; xx < x + blurSize && xx < image.Width; xx++)
                    {
                        for (int yy = y; yy < y + blurSize && yy < image.Height; yy++)
                        {
                            Color pixel = image.GetPixel(xx, yy);

                            // Используем lock для защиты общего ресурса (например, общего буфера)
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

                    result.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
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
            mutex.WaitOne(); // Начало критической секции
            try
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);

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
                mutex.ReleaseMutex(); // Конец критической секции
            }
        });

        return result;
    }
}
