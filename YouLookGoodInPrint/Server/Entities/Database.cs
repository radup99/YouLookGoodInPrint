using Microsoft.EntityFrameworkCore;
using System.Linq;
using YouLookGoodInPrint.Shared;


namespace YouLookGoodInPrint.Server.Entities
{
    public class Database : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        private static bool _created = false;

        public Database()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Document>().ToTable("Documents");
        }

        public void AddUser(string username, string password)
        {
            User user = new User(username, password);
            Users.Add(user);
            this.SaveChanges();
        }

        public void AddUser(string username, string password, string name, string email)
        {
            User user = new User(username, password, name, email);
            Users.Add(user);
            this.SaveChanges();
        }

        public bool UserExists(string username)
        {
            if (Users.Any(user => user.Username == username))
                return true;
            return false;
        }

        public bool PasswordIsCorrect(string username, string password)
        {
            if (Users.Any(user => user.Username == username && user.Password == password))
                return true;
            return false;
        }

        public string GetUserToken(string username)
        {
            return Users.Where(user => user.Username == username).Select(user => user.Token).ToArray()[0];
        }

        public void AddDocument(string name, string author)
        {
            Document document = new Document(name, author);
            Documents.Add(document);
            this.SaveChanges();
        }

        public void AddSampleData()
        {
            this.AddUser("stefan7", HashGenerator.GetHash("abcd"), "Stefan Popescu", "stefan7@gmail.com");
            this.AddUser("matei99", HashGenerator.GetHash("!qta76"), "Matei Dorin Enache", "mateidorin@gmail.com");
            this.AddDocument("New Document", "stefan7");
            this.AddDocument("Essay", "matei99");
        }
    }
}
