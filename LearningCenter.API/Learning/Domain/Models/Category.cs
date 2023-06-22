namespace LearningCenter.API.Learning.Domain.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Relationships
    
    public IList<Service> Services { get; set; } = new List<Service>();
    
}
