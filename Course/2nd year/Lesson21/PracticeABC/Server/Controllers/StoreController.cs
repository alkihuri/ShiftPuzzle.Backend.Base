namespace PracticeABC;

using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.IO; 
using System.Net.Http;
using System.Text; 
using System.Threading.Tasks;
using System.Collections.Generic;


[ApiController]
public class StoreController : ControllerBase
{
    
    private readonly SqlLiteProductRepository _productRepository;

    public StoreController(SqlLiteProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

        [HttpPost]
        [Route("/store/updateprice")]
        public IActionResult UpdatePrice(string name, double newPrice)
        {
            var product = _productRepository.GetProductByName(name);
            if (product != null)
            {
                product.Price = newPrice;
                _productRepository.UpdateProduct(product);
                return Ok($"{name} обновлен с новой ценой: {newPrice}");
            }
            else
            {
                return NotFound($"Продукт {name} не найден");
            }
        }

        [HttpPost]
        [Route("/store/updatename")]
        public IActionResult UpdateName(string currentName, string newName)
        {
            var product = _productRepository.GetProductByName(currentName);
            if (product != null)
            {
                product.Name = newName;
                _productRepository.UpdateProduct(product);
                return Ok($"Имя продукта изменено с {currentName} на {newName}");
            }
            else
            {
                return NotFound($"Продукт {currentName} не найден");
            }
        }

        [HttpGet]
        [Route("/store/outofstock")]
        public IActionResult OutOfStock()
        {
            var outOfStockItems = _productRepository.GetAllProducts().Where(p => p.Stock == 0).ToList();
            if (outOfStockItems.Any())
            {
                return Ok(outOfStockItems);
            }
            else
            {
                return Ok("Все продукты в наличии");
            }
        }

        [HttpPost]
        [Route("/store/auth")]
        public IActionResult Auth([FromBody] UserCredentials user)
        {
            if ((user.user == "admin") && (user.pass == "123"))
            {
                return Ok($"{user.user} авторизован");
            }
            else
            {
                return NotFound($"{user.user} не найден");
            }
        }

        [HttpPost]
        [Route("/store/add")]
        public IActionResult Add([FromBody] Product newProduct)
        { 
            _productRepository.AddProduct(newProduct);
            return Ok(_productRepository.GetAllProducts());
        }

        [HttpPost]
        [Route("/store/delete")]
        public IActionResult Delete(string name)
        {
            var product = _productRepository.GetProductByName(name);
            if (product != null)
            {
                _productRepository.DeleteProduct(name);
                return Ok($"{name} удален");
            }
            else
            {
                return NotFound($"{name} не найден");
            }
        }

        [HttpGet]
        [Route("/store/show")]
        public IActionResult Show()
        {
            return Ok(_productRepository.GetAllProducts());
        }
      

}