using Xunit;
using YouLookGoodInPrint.Server.Entities;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Controllers;

namespace YouLookGoodInPrint.Tests.Server
{
    public class PrintControllerTests
    {
        FakeDatabase Database = new FakeDatabase();
        string Token = "R0dudMbiXWqf7C1GKH4V";
        string Username = "admin";
        string Password = "admin";
        

        public void SetupDatabase()
        {
            User admin = new User(Username, Password.GetHash(), "", "");
            admin.Token = Token;

            Database.Users.Add(admin);
            Database.SaveChanges();
        }

        [Fact]
        public void TestTokenCheck()
        {
            SetupDatabase();
            PrintController controller = new PrintController(Database);
            string incorrectToken = "gqOzFeEequaoKj0FA3Ot";

            Print print = new Print("a63ace1a-2e91-4758-a98f-721d5a3da791", Username, "Landscape", "Black-and-White", 3);
            EntityData<Print> printData = new EntityData<Print>(print, Username, incorrectToken, "create");

            ServerMessage message = controller.Post(printData);
            Assert.Equal("Invalid token!", message.Message);
        }

        [Fact]
        public void TestAddPrint()
        {
            SetupDatabase();
            PrintController controller = new PrintController(Database);

            Print print = new Print("a63ace1a-2e91-4758-a98f-721d5a3da791", Username, "Landscape", "Black-and-White", 3);
            EntityData<Print> printData = new EntityData<Print>(print, Username, Token, "create");

            ServerMessage message = controller.Post(printData);
            Assert.Equal("Print request received successfully!", message.Message);
        }
    }
}
