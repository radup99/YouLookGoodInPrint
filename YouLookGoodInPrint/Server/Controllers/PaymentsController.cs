using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;
using YouLookGoodInPrint.Server.Entities;
using System.Collections.Generic;
using YouLookGoodInPrint.Shared.Entities;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("Payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentDataAccess Payments;
        private readonly TokenList Tokens;

        public PaymentsController(Database database, TokenList tokenList)
        {
            Database _database = database;
            Payments = new PaymentDataAccess(_database);
            Tokens = tokenList;
        }

        [HttpPost]
        public ServerMessage Post([FromBody] ItemData<List<Payment>> payData)
        {
            ServerMessage response = new ServerMessage();

            if (!Tokens.IsTokenValid(payData.Username, payData.Token))
            {
                response.Type = "error";
                response.Message = "Invalid token!";
                return response;
            }

            response.Type = "success";
            response.Message = "Print request received successfully!";

            foreach(Payment pr in payData.Item)
                Payments.Add(pr);

            return response;
        }

    }
}
