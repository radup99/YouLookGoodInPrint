using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Server.Entities
{
    public class PrintDataAccess
    {
        private readonly Database database = new Database();
        public void AddPrint(Print print)
        {
            database.Prints.Add(print);
            database.SaveChanges();
        }
    }
}
