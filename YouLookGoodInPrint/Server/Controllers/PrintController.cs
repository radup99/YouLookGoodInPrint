using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("Print")]
    public class PrintController : ControllerBase
    {
        private readonly PrintDataAccess Prints = new PrintDataAccess();

        [HttpPost]
        public ServerMessage Post([FromBody] Print printData)
        {
            ServerMessage response = new ServerMessage();
            Prints.Add(printData);
            return response;
        }

    }
}
