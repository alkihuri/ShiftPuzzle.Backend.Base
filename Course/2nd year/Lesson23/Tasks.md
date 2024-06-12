Привет! Тебе предстоить сделать рефакторинг проекта с предыдшуего урока. 

---
# Практика А:

1. Создать класс для перехода на EFCore 
    - EFCoreProductRepository
    - ProductContext


---
# Практика В: 

1. Реализовать логику методово интерфейса IProductRepository с LINQ запросами для  EFCoreProductRepository




# Практика C:

1.   Добавить регистрацию зависимостей

> Подсказка
```C#
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
```
 
