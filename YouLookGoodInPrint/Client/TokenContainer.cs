using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouLookGoodInPrint.Client
{
    public class TokenContainer
    {
        private string tokenString = "null";

        public string Property
        {
            get => tokenString;
            set
            {
                tokenString = value;
                NotifyStateChanged();
            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
