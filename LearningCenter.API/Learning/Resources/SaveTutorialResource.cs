using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Learning.Resources;

public class SaveTutorialResource
{
    // [Required]
    // [MaxLength(50)]
    // public string Title { get; set; }
    [Required]
    public int Price { get; set; }

    [Required]
    public string Location { get; set; }
    [Required]
    public bool castrado { get; set; }

    
    [MaxLength(120)]
    public string Description { get; set; }
    
    [Required]
    public int UserId { get; set; }
}