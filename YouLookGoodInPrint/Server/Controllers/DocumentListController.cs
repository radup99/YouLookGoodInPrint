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
        private readonly UserDataAccess Users = new UserDataAccess();
        private readonly DocumentDataAccess Documents = new DocumentDataAccess();

        [HttpPost]
        public List<Document> Post([FromBody] string token)
        {
            string username = Users.GetUsernameByToken(token);
            return Documents.GetByAuthor(username);
        }

    }
}
