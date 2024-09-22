using ConsoleApp1;

public class SaleRecordManager
{
    private List<SaleRecord> _records;

    public SaleRecordManager()
    {
        _records = new List<SaleRecord>();
    }
    
    public SaleRecordManager(List<SaleRecord> records)
    {
        _records = records;
    }

    // Создание записи
    public void AddRecord(SaleRecord record)
    {
        if (record == null)
        {
            throw new ArgumentNullException(nameof(record), "Record cannot be null");
        }
        _records.Add(record);
    }

    // Чтение всех записей
    public IEnumerable<SaleRecord> GetAllRecords()
    {
        return _records;
    }

    // Обновление записи
    public bool UpdateRecord(int index, SaleRecord updatedRecord)
    {
        if (index < 0 || index >= _records.Count)
        {
            return false; // индекс вне диапазона
        }
        if (updatedRecord == null)
        {
            throw new ArgumentNullException(nameof(updatedRecord), "Record cannot be null");
        }
        _records[index] = updatedRecord;
        return true;
    }

    // Удаление записи
    public bool DeleteRecord(int index)
    {
        if (index < 0 || index >= _records.Count)
        {
            return false; // индекс вне диапазона
        }
        _records.RemoveAt(index);
        return true;
    }

    // Поиск записей по продукту
    public IEnumerable<SaleRecord> GetRecordsByProduct(string product)
    {
        return _records.Where(r => r.Product.Equals(product, StringComparison.OrdinalIgnoreCase));
    }

    // Получение записи по индексу
    public SaleRecord GetRecordByIndex(int index)
    {
        if (index < 0 || index >= _records.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
        }
        return _records[index];
    }
    
    // Фильтрация данных по дате
    public IEnumerable<SaleRecord> FilterRecordsByDate(DateTime startDate, DateTime endDate)
    {
        return _records.Where(r => r.Date >= startDate && r.Date <= endDate);
    }

    // Фильтрация данных по региону
    public IEnumerable<SaleRecord> FilterRecordsByRegion(string region)
    {
        return _records.Where(r => r.Region.Equals(region, StringComparison.OrdinalIgnoreCase));
    }

    // Фильтрация данных по диапазону цен
    public IEnumerable<SaleRecord> FilterRecordsByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return _records.Where(r => r.Price >= minPrice && r.Price <= maxPrice);
    }

    // Получение общей суммы продаж
    public decimal GetTotalSales()
    {
        return _records.Sum(r => r.Price * r.Quantity);
    }

    // Получение среднего количества проданных товаров
    public double GetAverageQuantitySold()
    {
        return _records.Average(r => r.Quantity);
    }

    // Получение суммы продаж по продукту
    public decimal GetTotalSalesByProduct(string product)
    {
        return _records.Where(r => r.Product.Equals(product, StringComparison.OrdinalIgnoreCase))
            .Sum(r => r.Price * r.Quantity);
    }

    // Получение суммы продаж по региону
    public decimal GetTotalSalesByRegion(string region)
    {
        return _records.Where(r => r.Region.Equals(region, StringComparison.OrdinalIgnoreCase))
            .Sum(r => r.Price * r.Quantity);
    }
}