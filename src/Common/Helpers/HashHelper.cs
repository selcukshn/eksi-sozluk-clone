using System.Security.Cryptography;
using System.Text;

namespace Common.Helpers
{
    public class HashHelper
    {
        public static string GeneratePassword(string password) => HashWithSHA256(password);
        public static string HashWithSHA1(string value) => GenericHash(SHA1.Create(), value);
        public static string HashWithSHA256(string value) => GenericHash(SHA256.Create(), value);
        public static string HashWithSHA512(string value) => GenericHash(SHA512.Create(), value);
        public static string HashWithMD5(string value) => GenericHash(MD5.Create(), value);
        private static string GenericHash(HashAlgorithm hash, string value)
        {
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(byteArray);
        }
    }
}