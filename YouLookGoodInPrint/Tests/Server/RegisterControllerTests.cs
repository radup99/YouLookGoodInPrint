using Xunit;
using YouLookGoodInPrint.Server;
using Microsoft.EntityFrameworkCore;
using YouLookGoodInPrint.Server.Controllers;
using YouLookGoodInPrint.Server.Data;
using YouLookGoodInPrint.Server.Entities;
using YouLookGoodInPrint.Shared;
using Moq;

namespace YouLookGoodInPrint.Tests.Server
{
    public class RegisterControllerTests
    {
        FakeDatabase database = new FakeDatabase();
        TokenList tokenList;

        public void SetupDatabase()
        {
            User admin = new User("admin", "admin".GetHash(), "", "");
            database.Users.Add(admin);
            database.SaveChanges();

            tokenList = new TokenList(database);
        }
        [Fact]
        public void TestRegister()
        {
            SetupDatabase();
            RegisterController controller = new RegisterController(database, tokenList);

            string username = "ion44";
            string password = "!234gfh".GetHash();
            string realname = "Ion Popescu";
            string email = "ionpopescu@gmail.com";
            RegistrationData regData = new RegistrationData(username, password, realname, email);

            string message = controller.Post(regData);
            Assert.Equal("Registration complete!", message);
        }

        [Fact]
        public void TestExistingUsername()
        {
            SetupDatabase();
            RegisterController controller = new RegisterController(database, tokenList);

            string username = "admin";
            string password = "admin123".GetHash();
            string realname = "Admin";
            string email = "admin@gmail.com";
            RegistrationData regData = new RegistrationData(username, password, realname, email);

            string message = controller.Post(regData);
            Assert.Equal("Username already exists.", message);
        }
    }
}
