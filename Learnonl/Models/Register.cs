using System.ComponentModel.DataAnnotations;

namespace Learnonl.Models;

public class Register
{
    [Display(Name = "User Name")]
    [Required(ErrorMessage = "User Name is incorret")]
    [MaxLength(255, ErrorMessage = "Max 255 char")]
    public string Username { get; set; } = null!;

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is incorret")]
    [MaxLength(255, ErrorMessage = "Max 255 char")]
    public string Password { get; set; } = null!;

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email is incorret")]
    [EmailAddress]
    public string Email { get; set; } = null!;


}
