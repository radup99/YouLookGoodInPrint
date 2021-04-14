using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Entities;
using System.Collections.Generic;

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
            Prints.AddPrint(printData);
            return response;
        }

    }
}
