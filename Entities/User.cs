namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    //public Role Role { get; set; }
    //public string? Title { get; set; }
    //[JsonIgnore]
    //public string? PasswordHash { get; set; }
    public User()
    {
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }
}