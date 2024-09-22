namespace Shop.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    
    public Customer Customer { get; set; }
    public IEnumerable<Product> Products { get; set; }
}