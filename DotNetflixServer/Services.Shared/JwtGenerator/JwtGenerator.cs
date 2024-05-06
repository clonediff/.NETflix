using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Services.Shared.JwtGenerator;

public class JwtGenerator : IJwtGenerator
{
    private readonly SymmetricSecurityKey _key;
    private readonly string? _audience;
    private readonly string? _issuer;

    public JwtGenerator(IConfiguration config)
    {
        _issuer = config["JwtSettings:Issuer"];
        _audience = config["JwtSettings:Audience"];
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!));
    }
    
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName!),
            new(ClaimTypes.NameIdentifier, user.Id)
        };

        var jwt = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(3)),
            signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256));
            
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}