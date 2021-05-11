using System.Linq;
using YouLookGoodInPrint.Shared.Entities;
namespace YouLookGoodInPrint.Server.Data
{
    public class PaymentDataAccess : IDataAccess<Payment>
    {
        private readonly Database _database;

        public PaymentDataAccess(Database database)
        {
            _database = database;
        }

        public void Add(Payment item)
        {
            _database.Payments.Add(item);
            _database.SaveChanges();
        }
        public void Remove(string id)
        {
            Payment payment = _database.Payments.FirstOrDefault(p => p.Id == id);
            _database.Payments.Remove(payment);
            _database.SaveChanges();
        }

        public Payment Get(string id)
        {
            return _database.Payments.FirstOrDefault(p => p.Id == id);
        }

        public bool Exists(string id)
        {
            return _database.Payments.Any(p => p.Id == id);
        }

    }
}
