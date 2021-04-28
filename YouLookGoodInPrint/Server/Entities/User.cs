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

        public User(string username, string password, string name, string email)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Email = email;
        }
    }
}
