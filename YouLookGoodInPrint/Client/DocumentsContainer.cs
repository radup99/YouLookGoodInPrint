using System;
using System.Collections.Generic;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Client
{
    public class DocumentsContainer
    {
        private List<Document> _documents;
        private Document _currentDocument = new Document("", "", "", "0");
        private bool _noDocumentSelected = true;
        private List<Document> _oldVersions = new List<Document>();

        public List<Document> Documents
        {
            get => _documents;
            set
            {
                _documents = value;
                NotifyStateChanged();
            }
        }

        public List<Document> OldVersions
        {
            get => _oldVersions;
            set
            {
                _oldVersions = value;
                NotifyStateChanged();
            }
        }

        public Document CurrentDocument
        {
            get => _currentDocument;
            set
            {
                _currentDocument = value;
                NotifyStateChanged();
            }
        }

        public bool NoDocumentSelected
        {
            get => _noDocumentSelected;
            set
            {
                _noDocumentSelected = value;
                NotifyStateChanged();
            }
        }

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

            return new Document("", "", "", "0");
        }

        public void SelectDocument(Document document)
        {
            this._currentDocument = document;
            this.SetOldVersions(document.Id);
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

        public void SetOldVersions(string id)
        {
            List<Document> oldVers = new List<Document>();

            foreach (Document doc in _documents)
            {
                if (doc.ParentId == id)
                    oldVers.Add(doc);
            }

            oldVers.Sort((x, y) => DateTime.Compare(y.CreationDate, x.CreationDate));
            _oldVersions = oldVers;
            NotifyStateChanged();
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
