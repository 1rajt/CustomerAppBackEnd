namespace WebApi.Models.Users;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class UpdateRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }


    [EmailAddress]
    public string? Email { get; set; }

    public DateTime UpdatedDate { get; set; }

    public UpdateRequest()
    {
        UpdatedDate = DateTime.UtcNow;
    }

    private string? replaceEmptyWithNull(string? value)
    {
        // replace empty string with null to make field optional
        return string.IsNullOrEmpty(value) ? null : value;

    }
}