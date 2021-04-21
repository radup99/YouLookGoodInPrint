using System.Collections.Generic;
using System.Linq;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Server.Data
{
    public class DocumentDataAccess: IDataAccess<Document>
    {
        private readonly Database _database;

        public DocumentDataAccess(Database database)
        {
            _database = database;
        }

        public void Add(Document item)
        {
            _database.Documents.Add(item);
            _database.SaveChanges();
        }

        public void Remove(string id)
        {
            Document document = _database.Documents.FirstOrDefault(doc => doc.Id == id);
            _database.Documents.Remove(document);
        }

        public Document Get(string id)
        {
            return _database.Documents.FirstOrDefault(doc => doc.Id == id);
        }

        public List<Document> GetByAuthor(string name)
        {
            return _database.Documents.Where(doc => doc.Author == name).OrderBy(doc => doc.Name).ToList();
        }

        public bool Exists(string id)
        {
            return _database.Documents.Any(doc => doc.Id == id);
        }

        public void ModifyDocument(string id, Document updatedDocument)
        {
            Document document = _database.Documents.FirstOrDefault(doc => doc.Id == id);
            document.Name = updatedDocument.Name;
            document.Content = updatedDocument.Content;
            _database.SaveChanges();
        }

    }
}
