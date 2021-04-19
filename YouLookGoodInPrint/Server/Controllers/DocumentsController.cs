using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;


namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("Documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly UserDataAccess Users = new UserDataAccess();
        private readonly DocumentDataAccess Documents = new DocumentDataAccess();

        [HttpPost]
        public ServerMessage Post([FromBody] DocumentData docData)
        {
            ServerMessage response = new ServerMessage();

            if(!Users.isTokenValid(docData.Username, docData.Token))
            {
                response.Type = "error";
                response.Message = "Invalid token!";
                return response;
            }

            if (docData.Option == "delete")
            {
                Documents.Remove(docData.Document.Id);
                response.Type = "success";
                response.Message = "Document deleted.";
            }
            

            if (Documents.Exists(docData.Document.Id))
            {
                Documents.ModifyDocument(docData.Document.Id, docData.Document);
                response.Type = "success";
                response.Message = "Document saved successfully!";
            }

            else
            {
                Documents.Add(docData.Document);
                response.Type = "success";
                response.Message = "Document created successfully!";
            }

            return response;
        }

    }
}
