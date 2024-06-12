using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace Client
{


    [Serializable]
    public class Product
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string name { get; set; }

        [Range(0.01, 10000)] 
        public double price { get; set; }

        [Range(0, 10000)]
        public int stock { get; set; }

        public Product(string nname, double nprice, int nstock)
        {
            name = nname;
            price = nprice;
            stock = nstock;
        }

        public Product()
        {
            // Пустой конструктор
        }
    }

    public class Program
    {
        private const string BaseUrl = "http://localhost";
        private const string Port = "5087";
        private const string AuthMethod = "/store/auth";
        private const string AddProductMethod = "/store/add";
        private const string ShowProductsMethod = "/store/show";

        


        private static bool IsAuthorized = false;
        private static readonly HttpClient Client = new HttpClient();

        private static void DisplayProducts()
        {
            var url = $"{BaseUrl}:{Port}{ShowProductsMethod}";

            var response = Client.GetAsync(url).Result;
            var responseContent = response.Content.ReadAsStringAsync().Result; 
            Console.WriteLine(responseContent);
            var products = JsonSerializer.Deserialize<List<Product>>(responseContent);


            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("| Название продукта | Цена | Количество на складе |");
            Console.WriteLine("-----------------------------------------------------------------");

            foreach (var product in products)
            {
                Console.WriteLine($"| {product.name, -18} | {product.price, -5} | {product.stock, -19} |"); 
            }

            Console.WriteLine("-----------------------------------------------------------------");
        }

        private static void SendProduct()
        {
            if (!IsAuthorized)
            {
                Console.WriteLine("Вы не авторизованы");
                return;
            }

            var url = $"{BaseUrl}:{Port}{AddProductMethod}";

            Console.WriteLine("Введите название продукта:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите цену продукта:");
            var price = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество на складе:");
            var stock = int.Parse(Console.ReadLine());

            var product = new Product(name,price,stock); 

            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = Client.PostAsync(url, content).Result;

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

        private static void Auth()
        {
            var url = $"{BaseUrl}:{Port}{AuthMethod}";

            Console.WriteLine("Введите имя пользователя:");
            var user = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            var pass = Console.ReadLine();

            var userData = new
            {
                User = user,
                Pass = pass
            };

            var json = JsonSerializer.Serialize(userData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = Client.PostAsync(url, content).Result;

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

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1. Авторизация");
                Console.WriteLine("2. Отправить продукт");
                Console.WriteLine("3. Вывести список");
                Console.WriteLine("4. Выйти");
                Console.Write("Введите ваш выбор: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Auth();
                        break;
                    case "2":
                        if (!IsAuthorized)
                        {
                            Console.WriteLine("Вы не авторизованы.");
                            break;
                        }

                        SendProduct();
                        break;
                    case "3":
                        DisplayProducts();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
