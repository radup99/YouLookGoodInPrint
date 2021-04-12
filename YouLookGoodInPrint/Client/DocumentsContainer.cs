using System.Collections.Generic;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Client
{
    public class DocumentsContainer
    {
        public List<Document> documents;

        public Document currentDocument = new Document("", "", "");

        public void Clear()
        {
            documents = null;
        }

        public void selectDocument(Document document)
        {
            this.currentDocument = document;
        }
    }

}
