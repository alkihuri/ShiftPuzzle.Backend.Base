public class User
{ 

    public User(string name)
    {
        Name = name; 
    }

    public long ID { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }    
}