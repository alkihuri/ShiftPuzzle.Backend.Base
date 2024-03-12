
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class User
{ 

    public User(string name)
    {
        Name = name;
        // random value
        System.Random r = new Random(name.Length);  
    }

    public long ID { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; } 
    [JsonIgnore]
    public List<TrackerTask>? Tasks { get; set; }  
  
}