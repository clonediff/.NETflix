using Domain.Entities;

namespace Services.Shared.JwtGenerator;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}