using System;
using System.Collections.Generic;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Client
{
    public class DocumentsContainer
    {
        public List<Document> Documents;

        public Document CurrentDocument = new Document("", "", "");
        public bool NoDocumentSelected = true;

        public void Clear()
        {
            Documents = null;
            NotifyStateChanged();
        }

        public Document GetById(string id)
        {
            foreach (Document doc in Documents)
                if (doc.Id == id)
                {
                    return doc;
                }

            return new Document("", "", "");
        }

        public void SelectDocument(Document document)
        {
            this.CurrentDocument = document;
            NotifyStateChanged();
        }

        public void DeleteDocument(string id)
        {
            foreach(Document doc in Documents)
                if (doc.Id == id)
                {
                    Documents.Remove(doc);
                    NotifyStateChanged();
                }
        }

        public void DeleteDocument(Document document)
        {
            Documents.Remove(document);
            NotifyStateChanged();
        }

        public void AddDocument(Document document)
        {
            Documents.Add(document);
            SortByName();
            NotifyStateChanged();
        }

        public void SortByName()
        {
            Documents.Sort((x, y) => string.Compare(x.Name, y.Name));
        }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }

}
