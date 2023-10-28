using System.ComponentModel.DataAnnotations;

namespace Contracts.Forms;

public class LoginForm
{
    public string UserName { get; set; } = null!;
    
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    public bool Remember { get; set; }
}