using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Entities;
using System.Collections.Generic;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("Documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly Database database = new Database();

        [HttpPost]
        public IEnumerable<Document> Post([FromBody] string token)
        {
            string username = database.GetUsernameByToken(token);
            return database.GetDocumentsByAuthor(username);
        }
    }
}
