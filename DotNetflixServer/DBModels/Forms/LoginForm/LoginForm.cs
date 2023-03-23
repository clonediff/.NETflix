using System.ComponentModel.DataAnnotations;

namespace DBModels.Forms.LoginForm;

public class LoginForm
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    public bool Remember { get; set; }
}