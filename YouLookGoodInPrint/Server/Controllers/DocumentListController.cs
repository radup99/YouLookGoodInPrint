using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;
using System.Collections.Generic;
using YouLookGoodInPrint.Server.Entities;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("DocumentList")]
    public class DocumentListController : ControllerBase
    {
        private readonly DocumentDataAccess Documents;
        private readonly TokenList TokenList;

        public DocumentListController(Database database, TokenList tokenList)
        {
            Database _database = database;
            Documents = new DocumentDataAccess(_database);
            TokenList = tokenList;
        }

        [HttpPost]
        public List<Document> Post([FromBody] string token)
        {
            string username = TokenList.GetUsername(token);
            return Documents.GetByAuthor(username);
        }

    }
}
