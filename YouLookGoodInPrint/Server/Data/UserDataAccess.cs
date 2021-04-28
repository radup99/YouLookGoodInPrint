using System.Collections.Generic;
using System.Linq;
using YouLookGoodInPrint.Server.Entities;

namespace YouLookGoodInPrint.Server.Data
{
    public class UserDataAccess : IDataAccess<User>
    {
        private readonly Database _database;

        public UserDataAccess(Database database)
        {
            _database = database;
        }

        public void Add(User item)
        {
            _database.Users.Add(item);
            _database.SaveChanges();
        }

        public void Remove(string id)
        {
            User user = _database.Users.FirstOrDefault(user => user.Id == id);
            _database.Users.Remove(user);
        }

        public User Get(string id)
        {
            return _database.Users.FirstOrDefault(user => user.Id == id);
        }

        public List<string> GetAllUsernames()
        {
            return _database.Users.Select(user => user.Username).ToList();
        }

        public bool Exists(string id)
        {
            return _database.Users.Any(user => user.Id == id);
        }

        public bool UsernameExists(string username)
        {
            return _database.Users.Any(user => user.Username == username);
        }

        public bool IsPasswordCorrect(string username, string password)
        {
            if (_database.Users.Any(user => user.Username == username && user.Password == password))
                return true;
            return false;
        }
    }
}
