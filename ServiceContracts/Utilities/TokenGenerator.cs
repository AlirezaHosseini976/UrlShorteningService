using System.Security.Cryptography;

namespace ServiceContracts.Utilities;

public static class TokenGenerator
{
    public static string GenerateUniqueShortUrl()
    {
        const string availableChar = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        
            var bytes = new byte[6];
            RandomNumberGenerator.Fill(bytes);
            var chars = bytes.Select(b => availableChar[b % availableChar.Length]).ToArray();
            var token = new string(chars);
            return token;
        
    }
}