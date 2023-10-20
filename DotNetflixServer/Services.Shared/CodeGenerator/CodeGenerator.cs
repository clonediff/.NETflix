using System.Security.Cryptography;

namespace Services.Shared.CodeGenerator;

public class CodeGenerator : ICodeGenerator
{
    public string GenerateCode()
    {
        var randomBytes = new byte[4];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }
        return BitConverter.ToInt32(randomBytes, 0).ToString();
    }
}