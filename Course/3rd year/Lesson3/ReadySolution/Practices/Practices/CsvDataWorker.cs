using System.Globalization;
using ConsoleApp1;
using CsvHelper;

namespace Practices;

public class CsvDataWorker
{
    public static IEnumerable<SaleRecord> ReadData(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            return csv.GetRecords<SaleRecord>().ToList();
        }
    }
    
    public static void WriteData(string filePath, IEnumerable<dynamic> data)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecords(data);
        }
    }
}