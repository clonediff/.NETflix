using System.ComponentModel.DataAnnotations;

namespace DBModels.Forms.RegisterForm;

public class RegisterForm
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public DateTime Birthday { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}