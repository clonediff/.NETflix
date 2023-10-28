using System.ComponentModel.DataAnnotations;

namespace Contracts.Forms;

public class RegisterForm
{
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    public string UserName { get; set; } = null!;
    
    public DateTime Birthday { get; set; } 
    
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
}