//namespace WebApi.Models.Users;

//using System.ComponentModel.DataAnnotations;
//using WebApi.Entities;

//public class CreateRequest
//{
//    [Required]
//    public string? Title { get; set; }

//    [Required]
//    public string? FirstName { get; set; }

//    [Required]
//    public string? LastName { get; set; }

//    [Required]
//    [EnumDataType(typeof(Role))]
//    public string? Role { get; set; }

//    [Required]
//    [EmailAddress]
//    public string? Email { get; set; }

//    [Required]
//    [MinLength(6)]
//    public string? Password { get; set; }

//    [Required]
//    [Compare("Password")]
//    public string? ConfirmPassword { get; set; }
//}
namespace WebApi.Models.Users;

using System;
using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateRequest
{
    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string? Email { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public CreateRequest()
    {
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }
}
