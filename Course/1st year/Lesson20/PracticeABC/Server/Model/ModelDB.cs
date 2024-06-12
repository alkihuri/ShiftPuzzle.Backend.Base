namespace PracticeABC; 
using System.Text.Json; 
using System.Collections.Generic; 

public class ProductRepository
    {

        
        private List<Product> _products;
        private readonly string _jsonFilePath;

        public ProductRepository(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
            ReadDataFromFile();
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductByName(string name)
        {
            return _products.FirstOrDefault(p => p.Name == name);
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
            SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                SaveChanges();
            }
        }

        public void DeleteProduct(string name)
        {
            var product = _products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                _products.Remove(product);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_products, options);
            System.IO.File.WriteAllText(_jsonFilePath, json);
        }

        private void ReadDataFromFile()
        {
            if (DBExist())
            {
                var json = ReadDB();
                _products = JsonSerializer.Deserialize<List<Product>>(json);
            }
            else
            {
                _products = new List<Product>();
            }
        }

        private string ReadDB()
        {
            return System.IO.File.ReadAllText(_jsonFilePath);
        }

        private bool DBExist()
        {
            return System.IO.File.Exists(_jsonFilePath);
        }
    }