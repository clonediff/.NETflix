using System.ComponentModel.DataAnnotations;

namespace Contracts.Forms;

public class RegisterForm
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    public string UserName { get; set; } = null!;
    
    [Required]
    public DateTime Birthday { get; set; } 
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;
}