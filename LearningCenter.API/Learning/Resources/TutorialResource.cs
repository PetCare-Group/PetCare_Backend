using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Resources;

namespace LearningCenter.API.Learning.Resources;

public class ServiceResource
{
    public int Id { get; set; }
    public int Price { get; set; }

    public string Location { get; set; }
    public string review { get; set; }

    public string phone { get; set; }
    public string dni { get; set; }
    public string typeService { get; set; }

    public string Description { get; set; }
    // public CategoryResource Category { get; set; }
    public UserResource User { get; set; }
}