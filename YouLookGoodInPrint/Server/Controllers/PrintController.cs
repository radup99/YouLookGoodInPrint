using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("Print")]
    public class PrintController : ControllerBase
    {
        private readonly UserDataAccess Users = new UserDataAccess();
        private readonly PrintDataAccess Prints = new PrintDataAccess();

        [HttpPost]
        public ServerMessage Post([FromBody] EntityData<Print> printData)
        {
            ServerMessage response = new ServerMessage();

            if (!Users.isTokenValid(printData.Username, printData.Token))
            {
                response.Type = "error";
                response.Message = "Invalid token!";
                return response;
            }

            response.Type = "success";
            response.Message = "Document created successfully!";
            Prints.Add(printData.Item);
            return response;
        }

    }
}
