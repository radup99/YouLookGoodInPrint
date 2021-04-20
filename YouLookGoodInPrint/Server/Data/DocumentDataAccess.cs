using System.Collections.Generic;
using System.Linq;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Server.Data
{
    public class DocumentDataAccess: IDataAccess<Document>
    {
        private readonly Database database = new Database();

        public void Add(Document item)
        {
            database.Documents.Add(item);
            database.SaveChanges();
        }

        public void Remove(string id)
        {
            Document document = database.Documents.FirstOrDefault(doc => doc.Id == id);
            database.Documents.Remove(document);
        }

        public Document Get(string id)
        {
            return database.Documents.FirstOrDefault(doc => doc.Id == id);
        }

        public bool Exists(string id)
        {
            return database.Documents.Any(doc => doc.Id == id);
        }

        public void ModifyDocument(string id, Document updatedDocument)
        {
            Document document = database.Documents.FirstOrDefault(doc => doc.Id == id);
            document.Name = updatedDocument.Name;
            document.Content = updatedDocument.Content;
            database.SaveChanges();
        }

        public List<Document> GetDocumentsByAuthor(string name)
        {
            return database.Documents.Where(doc => doc.Author == name).OrderBy(doc => doc.Name).ToList();
        }


    }
}
