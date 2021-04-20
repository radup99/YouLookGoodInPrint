using Xunit;
using YouLookGoodInPrint.Server;
using Microsoft.EntityFrameworkCore;
using YouLookGoodInPrint.Server.Controllers;
using YouLookGoodInPrint.Server.Data;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Tests.Server
{
    public class SignInControllerTests
    {
        [Fact]
        public void TestLogin()
        {
            var database = new Database();
            var controller = new SignInController();

            string username = "admin";
            string password = "admin".GetHash();
            Credentials credentials = new Credentials(username, password);

            ServerMessage message = controller.Post(credentials);
            Assert.Equal("a", message.Message);
        }
    }
}
