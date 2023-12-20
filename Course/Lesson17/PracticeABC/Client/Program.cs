using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;

namespace Client;

class Program
{ 
    [System.Serializable]
    public class Product
    {
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string name { get; set; }

    [Range(0.01, 10000)]
    public double price { get; set; }

    [Range(0, 10000)]
    public int stock { get; set; }

        
    }
    
    static bool IsAuthorized = false;

    static void DisplayProducts()
        {
            var url = "http://localhost:5087/store/show"; // Замените на порт вашего сервера
            
            // реализуй логику


            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("| Название продукта | Цена | Количество на складе |"); 



            Console.WriteLine("-----------------------------------------------------------------");
        }


    public static void SendProduct()
    {        
            if(!IsAuthorized)
            {
                Console.WriteLine("Вы не авторизованы");
                return;        
            }
        
            var url = "http://localhost:5087/store/add"; // Замените на порт вашего сервера
            Console.WriteLine("Введите название продукта:");
            var name = Console.ReadLine();
            Console.WriteLine("Введите цену продукта:");
            var price = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество на складе:");
            var stock = int.Parse(Console.ReadLine());

            var product = new
            {
                Name = name,
                Price = price,
                Stock = stock
            };

            var client = new HttpClient(); 
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseContent);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
    }


    public static void Auth()
    {       
        
        
            var url = "http://localhost:5087/store/????"; // Замените на порт вашего сервера, также замените символы на правильный апи
            var userData = new
            {
                User = "admin",
                Pass = "123"
            };

            var client = new HttpClient(); 
            var json = JsonSerializer.Serialize(userData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseContent);
                IsAuthorized = true;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                IsAuthorized = false;
            }
    }


    static void Main(string[] args)
    { 
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
                {
                    Console.WriteLine("Выберите опцию:");
                     

                    var choice = Console.ReadLine();

                    switch (choice)
                    { 
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
    }
}