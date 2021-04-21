using System.Linq;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Server.Data
{
    public class PrintDataAccess : IDataAccess<Print>
    {
        private readonly Database _database;

        public PrintDataAccess(Database database)
        {
            _database = database;
        }

        public void Add(Print item)
        {
            _database.Prints.Add(item);
            _database.SaveChanges();
        }
        public void Remove(string id)
        {
            Print print = _database.Prints.FirstOrDefault(p => p.Id == id);
            _database.Prints.Remove(print);
            _database.SaveChanges();
        }

        public Print Get(string id)
        {
            return _database.Prints.FirstOrDefault(p => p.Id == id);
        }

        public bool Exists(string id)
        {
            return _database.Documents.Any(doc => doc.Id == id);
        }

    }
}
