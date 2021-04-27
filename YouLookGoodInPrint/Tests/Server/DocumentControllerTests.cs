using Xunit;
using YouLookGoodInPrint.Server.Entities;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Controllers;

namespace YouLookGoodInPrint.Tests.Server
{
    public class DocumentControllerTests
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
            DocumentsController controller = new DocumentsController(Database);
            string incorrectToken = "gqOzFeEequaoKj0FA3Ot";

            Document document = new Document("New Document", "admin", "Sample Content");
            ItemData<Document> docData = new ItemData<Document>(document, Username, incorrectToken, "create");

            ServerMessage message = controller.Post(docData);
            Assert.Equal("Invalid token!", message.Message);
        }

        [Fact]
        public void TestCreateDocument()
        {
            SetupDatabase();
            DocumentsController controller = new DocumentsController(Database);

            Document document = new Document("Test Document", Username, "Test");
            ItemData<Document> docData = new ItemData<Document>(document, Username, Token, "create");

            ServerMessage message = controller.Post(docData);
            Assert.Equal("Document created successfully!", message.Message);

            Document editedDocument = document;
            document.Content = "Modified content";
            ItemData<Document> modifDocData = new ItemData<Document>(editedDocument, Username, Token, "create");

            ServerMessage message2 = controller.Post(docData);
            Assert.Equal("Document saved successfully!", message2.Message);
        }
    }
}
