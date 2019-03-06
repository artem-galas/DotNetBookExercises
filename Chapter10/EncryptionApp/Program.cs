using System;
using CryptographyLib;

namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // BasicCrypto();
            // UserCrypto();
            CheckSignature();
            // CheckRandom();
        }

        static void CheckRandom()
        {
            Console.Write("How big do you want the key (in bytes): ");
            string size = Console.ReadLine();
            byte[] key = Protector.GetRandomKeyOrIV(int.Parse(size));
            Console.WriteLine($"Key as byte array:");
            for (int b = 0; b < key.Length; b++)
            {
                Console.Write($"{key[b]:x2} ");
                if (((b + 1) % 16) == 0) Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void CheckSignature()
        {
            Console.Write("Enter some text to sign: ");
            string data = Console.ReadLine();
            var signature = Protector.GenerateSignature(data);
            Console.WriteLine($"Signature: {signature}");
            Console.WriteLine("Public key used to check signature:");
            Console.WriteLine(Protector.PublicKey);
            if (Protector.ValidateSignature(data, signature))
            {
                Console.WriteLine("Correct! Signature is valid.");
            }
            else
            {
                Console.WriteLine("Invalid signature.");
            }

            var fakeSignature = signature.Replace(signature[0], 'X');
            if (Protector.ValidateSignature(data, fakeSignature))
            {
                Console.WriteLine("Correct! Signature is valid.");
            }
            else
            {
                Console.WriteLine($"Invalid signature: {fakeSignature}");
            }
        }

        static void UserCrypto()
        {
            Console.WriteLine("A user named Alice has been registered with Pa$$w0rd as her password.");
            var alice = Protector.Register("Alice", "Pa$$w0rd");
            Console.WriteLine($"Name: {alice.Name}");
            Console.WriteLine($"Salt: {alice.Salt}");
            Console.WriteLine($"Salted and hashed password: {alice.SaltedHashedPassword}");
            Console.WriteLine();
            Console.Write("Enter a different username to register: ");

            string username = Console.ReadLine();
            Console.Write("Enter a password to register: ");
            string password = Console.ReadLine();
            var user = Protector.Register(username, password);
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Salt: {user.Salt}");
            Console.WriteLine($"Salted and hashed password: {user.SaltedHashedPassword}");

            bool correctPassword = false;
            while (!correctPassword)
            {
                Console.Write("Enter a username to log in: ");
                string loginUsername = Console.ReadLine();
                Console.Write("Enter a password to log in: ");
                string loginPassword = Console.ReadLine();
                correctPassword = Protector.CheckPassword(loginUsername,
                loginPassword);
                if (correctPassword)
                {
                    Console.WriteLine($"Correct! {loginUsername} has been logged in.");
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Try again.");
                }
            }
        }

        static void BasicCrypto()
        {
            Console.Write("Enter a message that you want to encrypt: ");
            string message = Console.ReadLine();

            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            string cryptoText = Protector.Encrypt(message, password);
            Console.WriteLine($"Encrypted text: {cryptoText}");

            Console.Write("Enter the password: ");
            string password2 = Console.ReadLine();

            try
            {
                string clearText = Protector.Decrypt(cryptoText, password2);
                Console.WriteLine($"Decrypted text: {clearText}");
            }
            catch
            {
                Console.WriteLine("Enable to decrypt because you entered the wrong password!");
            }
        }
    }
}
