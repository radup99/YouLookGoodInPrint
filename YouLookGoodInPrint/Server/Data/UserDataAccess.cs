using System.Linq;
using YouLookGoodInPrint.Server.Entities;

namespace YouLookGoodInPrint.Server.Data
{
    public class UserDataAccess : IDataAccess<User>
    {
        private readonly Database database = new Database();

        public void Add(User user)
        {
            database.Users.Add(user);
            database.SaveChanges();
        }

        public void Remove(string id)
        {
            User user = database.Users.FirstOrDefault(user => user.Id == id);
            database.Users.Remove(user);
        }

        public User Get(string id)
        {
            return database.Users.FirstOrDefault(user => user.Id == id);
        }

        public bool Exists(string id)
        {
            return database.Users.Any(user => user.Id == id);
        }

        public bool UsernameExists(string username)
        {
            return database.Users.Any(user => user.Username == username);
        }

        public bool IsPasswordCorrect(string username, string password)
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
