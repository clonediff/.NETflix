﻿using System.ComponentModel.DataAnnotations;

namespace Contracts.Admin.Authentication;

public class LoginForm
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}