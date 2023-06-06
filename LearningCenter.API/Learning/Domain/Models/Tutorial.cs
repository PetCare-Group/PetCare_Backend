using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Models;


public class Tutorial
{
    public int Id { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    
    public string Location { get; set; }
    public bool castrado { get; set; }
    // Relationships
    // public int CategoryId { get; set; }
    public int UserId { get; set; }
    // public Category Category { get; set; }
    public User User { get; set; }

    // public IList<User> Users { get; set; } = new List<User>();

}