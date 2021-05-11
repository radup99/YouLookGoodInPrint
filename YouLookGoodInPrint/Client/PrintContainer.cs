using System;
using System.Collections.Generic;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Client
{
    public class PrintContainer
    {
        private List<Print> _prints = new List<Print>();

        private Print _currentPrint = new Print("", "", "", "", 0);

        public List<Print> Prints
        {
            get => _prints;
            set
            {
                _prints = value;
                NotifyStateChanged();
            }
        }

        public Print CurrentPrint
        {
            get => _currentPrint;
            set
            {
                _currentPrint = value;
                NotifyStateChanged();
            }
        }

        public void Clear()
        {
            _prints = null;
        }

        public void selectPrint(Print print)
        {
            this._currentPrint = print;
        }

        public Print GetById(string id)
        {
            foreach (Print pr in Prints)
                if (pr.Id == id)
                {
                    return pr;
                }

            return new Print("", "", "", "", 0);
        }

        public void DeletePrint(string id)
        {
            foreach (Print pr in Prints)
                if (pr.Id == id)
                {
                    Prints.Remove(pr);
                    NotifyStateChanged();
                }
        }

        public void AddPrint(Print print)
        {
            Prints.Add(print);
            NotifyStateChanged();
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
