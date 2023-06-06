using System.Text.Json.Serialization;
using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }

    public Tutorial Tutorial { get; set; }


    [JsonIgnore]
    public string PasswordHash { get; set; }
}