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
        public ServerMessage Post([FromBody] EntityData<Document> docData)
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
                Documents.Remove(docData.Item.Id);
                response.Type = "success";
                response.Message = "Document deleted.";
            }
            

            if (Documents.Exists(docData.Item.Id))
            {
                Documents.ModifyDocument(docData.Item.Id, docData.Item);
                response.Type = "success";
                response.Message = "Document saved successfully!";
            }

            else
            {
                Documents.Add(docData.Item);
                response.Type = "success";
                response.Message = "Document created successfully!";
            }

            return response;
        }

    }
}
