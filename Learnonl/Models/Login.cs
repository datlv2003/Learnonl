using System.ComponentModel.DataAnnotations;

namespace Learnonl.Models;

public class Login
{
    [Display(Name = "User Name")]
    [Required(ErrorMessage = "User Name is incorret")]
    [MaxLength(255, ErrorMessage = "Max 255 char")]
    public string? Username { get; set; }
    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is incorret")]
    [MaxLength(255, ErrorMessage = "Max 255 char")]
    public string? Password { get; set; }
    public string? UserId { get; set; }
    public enum UserRoles
    {
        Admin,
        Student,
        Teacher
    }
}