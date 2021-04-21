using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;
using System.Collections.Generic;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("DocumentList")]
    public class DocumentListController : ControllerBase
    {
        private readonly UserDataAccess Users;
        private readonly DocumentDataAccess Documents;

        public DocumentListController(Database database)
        {
            Database _database = database;
            Users = new UserDataAccess(_database);
            Documents = new DocumentDataAccess(_database);
        }

        [HttpPost]
        public List<Document> Post([FromBody] string token)
        {
            string username = Users.GetUsernameByToken(token);
            return Documents.GetByAuthor(username);
        }

    }
}
