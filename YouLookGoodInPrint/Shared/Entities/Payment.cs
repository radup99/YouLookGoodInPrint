using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouLookGoodInPrint.Shared.Entities
{
    public class Payment
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public string DocumentTitle { get; set; }
        public string PrintId { get; set; }

        public double Price { get; set; }


        public Payment (string username, string documentTitle, string printId, double price)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Username = username;
            this.DocumentTitle = documentTitle;
            this.PrintId = printId;
            this.Price = price;
        }
    }
}