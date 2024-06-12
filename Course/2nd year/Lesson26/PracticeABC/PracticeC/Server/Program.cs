using Microsoft.EntityFrameworkCore;
using PracticeABC;
using System.Data.SQLite; // Добавляем пространство имен для работы с SQLite
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы в контейнер.
builder.Services.AddControllers();

// Добавляем поддержку Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Регистрируем ProductRepository
builder.Services.AddSingleton<IProductRepository>(provider =>
{
    // Создаем экземпляр DbContextOptionsBuilder для конфигурации базы данных SQLite
    var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
    optionsBuilder.UseSqlite("Data Source=DataBase.db");

    // Создаем экземпляр ProductContext с передачей объекта optionsBuilder.Options
    var productContext = new ProductContext(optionsBuilder.Options);
    
    // Создаем экземпляр репозитория и передаем контекст базы данных
    IProductRepository productRepository = new EFCoreProductRepository(productContext);
    
    return productRepository;
});

var app = builder.Build();

// Настраиваем конвейер обработки HTTP-запросов.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

 