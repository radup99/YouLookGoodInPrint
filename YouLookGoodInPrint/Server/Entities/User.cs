using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace YouLookGoodInPrint.Server.Entities
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public User(string username, string password, string name, string email)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Email = email;
            this.Token = GenerateToken();
        }
        private static string GenerateToken()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var token = new char[20];

            for (int i = 0; i < 19; i++)
            {
                int index = User.SecureRandInt(0, chars.Length);
                token[i] = chars[index];
            }

            return new string(token);
        }

        private static int SecureRandInt(int min, int max)
        {
            RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();
            uint scale = uint.MaxValue;

            while (scale == uint.MaxValue)
            {
                byte[] four_bytes = new byte[4];
                Rand.GetBytes(four_bytes);

                scale = BitConverter.ToUInt32(four_bytes, 0);
            }

            return (int)(min + (max - min) * (scale / (double)uint.MaxValue));
        }
    }
}
