using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Managers.Implementations;
using Shop.Managers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<IOrderManager, OrderManager>();
builder.Services.AddScoped<ICustomerManager, CustomerManager>();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SQLite")));

var app = builder.Build();

using var serviceScope = app.Services.CreateScope();

try
{
    var appContextService = serviceScope.ServiceProvider.GetRequiredService<DataContext>();

    appContextService.Database.Migrate();
}
catch (Exception exc)
{
    app.Logger.LogError(message: "Ошибка миграции базы данных: {exc}", exc);
    throw;
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();