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

        public string GetUserToken(string username)
        {
            return _database.Users.Where(user => user.Username == username).Select(user => user.Token).ToArray()[0];
        }

        public string GetUsernameByToken(string token)
        {
            return _database.Users.Where(user => user.Token == token).Select(user => user.Username).ToArray()[0];
        }

        public bool isTokenValid(string username, string token)
        {
            return (_database.Users.Where(user => user.Username == username).Select(user => user.Token).ToArray()[0] == token);
        }
    }
}
