using System.Globalization;

// Практика А
// Задание 1. Сделайте так, чтобы код заработал! Для этого создайте недостающие классы City и GeoLocation.
void Main()
{
    var city = new City();  
    city.Name = "Ekaterinburg";
    city.Location = new GeoLocation();
    city.Location.Latitude = 56.50;
    city.Location.Longitude = 60.35;
    Console.WriteLine("I love {0} located at ({1}, {2})", 
        city.Name, 
        city.Location.Longitude.ToString(CultureInfo.InvariantCulture),
        city.Location.Latitude.ToString(CultureInfo.InvariantCulture));
}