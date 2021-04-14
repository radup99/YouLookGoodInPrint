using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouLookGoodInPrint.Server.Entities
{
    public class UserDataAccess
    {
        private readonly Database database = new Database();

        public void AddUser(string username, string password)
        {
            User user = new User(username, password);
            database.Users.Add(user);
            database.SaveChanges();
        }

        public void AddUser(string username, string password, string name, string email)
        {
            User user = new User(username, password, name, email);
            database.Users.Add(user);
            database.SaveChanges();
        }

        public bool UserExists(string username)
        {
            if (database.Users.Any(user => user.Username == username))
                return true;
            return false;
        }

        public bool PasswordIsCorrect(string username, string password)
        {
            if (database.Users.Any(user => user.Username == username && user.Password == password))
                return true;
            return false;
        }

        public string GetUserToken(string username)
        {
            return database.Users.Where(user => user.Username == username).Select(user => user.Token).ToArray()[0];
        }

        public string GetUsernameByToken(string token)
        {
            return database.Users.Where(user => user.Token == token).Select(user => user.Username).ToArray()[0];
        }

        public bool isTokenValid(string username, string token)
        {
            return (database.Users.Where(user => user.Username == username).Select(user => user.Token).ToArray()[0] == token);
        }
    }
}
