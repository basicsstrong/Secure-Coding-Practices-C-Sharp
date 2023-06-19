using System.Security;
using System.Security.Cryptography;

class Authentication
{  
    public static void Trigger()
    {
        Console.Write("Enter your username: ");
        string? username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string? password = Console.ReadLine();

        if (username != null && password != null && AuthenticateUser(username, password))
        {
            Console.WriteLine("Authentication successful!");
        }
        else
        {
            Console.WriteLine("Authentication failed!");
        }
    }

    public static bool AuthenticateUser(string? username, string? password)
    {
        string passwordFromDatabase = GetHashedPasswordFromDatabase(username);

        string salt = GenerateSalt();

        string saltedPassword = password + salt;

        string hashpassword = HashPassword(saltedPassword);

        if (passwordFromDatabase.Equals(hashpassword))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static string HashPassword(string saltedPassword)
    {
        
       byte[] hashedBytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(saltedPassword));
       String hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "");
       Console.WriteLine($"password: {hashedPassword}");
       return hashedPassword;
    }

    private static string GenerateSalt()
    {
       return "somerandomsaltvalue";
    }

    private static string GetHashedPasswordFromDatabase(string? username)
    {   Console.WriteLine("Getting password from DB for {0}", username);
        return "DEE1DC29CABAA96E3CC1D0515AA641055C431333310FEF2A6C5DE543823BBEEF";
    }


//Sensitive Data Protection

    public static SecureString GetAsSecureString(char[] chars)
    {
        if (chars == null)
            throw new ArgumentNullException(nameof(chars));

        SecureString secureString = new();

        foreach (char c in chars)
        {
            secureString.AppendChar(c);
        }

        secureString.MakeReadOnly();

        return secureString;
    }
 }  