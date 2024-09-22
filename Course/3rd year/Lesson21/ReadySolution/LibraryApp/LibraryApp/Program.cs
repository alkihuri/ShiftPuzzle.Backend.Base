using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LibraryApp.Data;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<LibraryContext>(options =>
                options.UseSqlite("Data Source=library.db"))
            .BuildServiceProvider();

        using (var context = serviceProvider.GetService<LibraryContext>())
        {
            context.Database.Migrate();  // Применение миграций и создание базы данных
        }
    }
}