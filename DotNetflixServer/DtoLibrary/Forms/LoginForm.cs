using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models.Forms;

public class LoginForm
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    public bool Remember { get; set; }
}