using System.Linq;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Server.Data
{
    public class PrintDataAccess : IDataAccess<Print>
    {
        private readonly Database database = new Database();
        public void Add(Print item)
        {
            database.Prints.Add(item);
            database.SaveChanges();
        }
        public void Remove(string id)
        {
            Print print = database.Prints.FirstOrDefault(p => p.Id == id);
            database.Prints.Remove(print);
            database.SaveChanges();
        }

        public Print Get(string id)
        {
            return database.Prints.FirstOrDefault(p => p.Id == id);
        }

        public bool Exists(string id)
        {
            return database.Documents.Any(doc => doc.Id == id);
        }

    }
}
