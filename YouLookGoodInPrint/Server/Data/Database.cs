using Microsoft.EntityFrameworkCore;
using YouLookGoodInPrint.Server.Entities;
using YouLookGoodInPrint.Shared;


namespace YouLookGoodInPrint.Server.Data
{
    public class Database : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Print> Prints { get; set; }
        //private static bool _created = false;

        public Database()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Document>().ToTable("Documents");
            modelBuilder.Entity<Print>().ToTable("Prints");
        }
    }
}
