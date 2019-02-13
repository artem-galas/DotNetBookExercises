using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Exercise10
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
        public string BcryptCardNumber { get; set; }
        private static readonly int iterations = 20000;

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Customer(string fullName)
        {
            FirstName = fullName.Split(' ')[0];
            LastName = fullName.Split(' ')[1];
        }

        public static Customer Register(
            string firstName,
            string lastName,
            string password,
            string cardNumber
        )
        {
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);

            var sha = SHA256.Create();
            var saltedPassword = password + saltText;
            var saltedHashedPassword = Convert.ToBase64String(
                sha.ComputeHash(
                    Encoding.Unicode.GetBytes(saltedPassword)
                )
            );

            return new Customer(firstName, lastName) {
                Salt = saltText,
                HashedPassword = saltedHashedPassword,
                BcryptCardNumber = EncryptCardNumber(cardNumber, password, Encoding.Unicode.GetBytes(saltText))
            };
        }

        public string DecryptCardNumber(string bcryptedCardNumber, string password)
        {
            if (!CheckPassword(password)) {
                throw new ArgumentException($"Wrong Password for {this.Name}");
            }

            byte[] cryptoBytes = Convert.FromBase64String(bcryptedCardNumber);
            var aes = Aes.Create();
            var saltedBytes = Encoding.Unicode.GetBytes(this.Salt);
            
            var pbkdf2 = new Rfc2898DeriveBytes(password, saltedBytes, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);

            var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(cryptoBytes, 0, cryptoBytes.Length);
            }

            return Encoding.Unicode.GetString(ms.ToArray());
        }

        public static string EncryptCardNumber(string cardNumber, string password, byte[] salt)
        {
            byte[] plainBytes = Encoding.Unicode.GetBytes(cardNumber);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);

            var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, plainBytes.Length);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public bool CheckPassword(string password)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + this.Salt;
            var saltedHashedPassword = Convert.ToBase64String(
                sha.ComputeHash(
                    Encoding.Unicode.GetBytes(saltedPassword)
                )
            );

            return (saltedHashedPassword == this.HashedPassword);
        }
    }
}