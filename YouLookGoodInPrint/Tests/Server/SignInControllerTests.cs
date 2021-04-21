using Xunit;
using YouLookGoodInPrint.Server.Controllers;
using YouLookGoodInPrint.Server.Entities;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Tests.Server
{
    public class SignInControllerTests
    {
        FakeDatabase database = new FakeDatabase();

        public void SetupDatabase()
        {
            User admin = new User("admin", "admin".GetHash(), "", "");
            User matei = new User("matei33", "abcd123".GetHash(), "", "");
            database.Users.Add(admin);
            database.Users.Add(matei);
            database.SaveChanges();
        }
        [Fact]
        public void TestLogin()
        {
            SetupDatabase();
            SignInController controller = new SignInController(database);

            string username = "admin";
            string password = "admin".GetHash();
            Credentials credentials = new Credentials(username, password);

            ServerMessage message = controller.Post(credentials);
            Assert.Equal("token", message.Type);
        }

        [Fact]
        public void TestIncorrectPassword()
        {
            SetupDatabase();
            SignInController controller = new SignInController(database);

            string username = "matei33";
            string password = "matei33".GetHash();
            Credentials credentials = new Credentials(username, password);

            ServerMessage message = controller.Post(credentials);
            Assert.Equal("Incorrect password.", message.Message);
        }

        [Fact]
        public void TestNonExistentUsername()
        {
            SetupDatabase();
            SignInController controller = new SignInController(database);

            string username = "john4";
            string password = "password".GetHash();
            Credentials credentials = new Credentials(username, password);

            ServerMessage message = controller.Post(credentials);
            Assert.Equal("Username does not exist.", message.Message);
        }
    }
}
