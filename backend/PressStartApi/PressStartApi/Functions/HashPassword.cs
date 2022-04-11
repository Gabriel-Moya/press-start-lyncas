using System.Security.Cryptography;
using System.Text;

namespace PressStartApi.Functions
{
    public class HashPassword
    {
        public static string HashingPassword(string password)
        {
            string salt = "7MORb9gSXiPPb6zCXYKUmA";
            password += salt;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
