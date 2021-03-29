using System;
using System.ComponentModel.DataAnnotations;

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

        public User(string username, string password)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Username = username;
            this.Password = password;
            this.Token = this.GenerateToken();
        }

        public User(string username, string password, string name, string email)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Email = email;
            this.Token = this.GenerateToken();
        }
        private string GenerateToken()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var token = new char[20];
            var random = new Random();

            for (int i = 0; i < 19; i++)
            {
                token[i] = chars[random.Next(chars.Length)];
            }

            return new string(token);
        }
    }
}
