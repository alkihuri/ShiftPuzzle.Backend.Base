using System;

public class TrackerTask
{  
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsComplete { get; set; } 
    public DateTime? DueDate { get; set; }

    public User? AssignedUser { get; set; }
  
}
 