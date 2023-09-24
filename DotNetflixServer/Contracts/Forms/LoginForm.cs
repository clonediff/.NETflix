using System.ComponentModel.DataAnnotations;

namespace Contracts.Forms;

public class LoginForm
{
    [Required]
    public string UserName { get; set; } = null!;
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    public bool Remember { get; set; }
}