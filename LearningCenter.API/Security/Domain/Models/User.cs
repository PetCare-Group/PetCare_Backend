using System.Text.Json.Serialization;
using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }

    public Service Service { get; set; }


    public IList<Payment> Payments { get; set; }= new List<Payment>();

    [JsonIgnore]
    public string PasswordHash { get; set; }
}