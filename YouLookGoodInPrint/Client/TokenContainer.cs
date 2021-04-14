using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouLookGoodInPrint.Client
{
    public class TokenContainer
    {
        private string _token = "null";
        private string _username = "";

        public string Token
        {
            get => _token;
            set
            {
                _token = value;
                NotifyStateChanged();
            }
        }

        public string UserName
        {
            get => _username;
            set
            {
                _username = value;
                NotifyStateChanged();
            }
        }

        public void Clear()
        {
            _token = "null";
            _username = "";
        }

        /*
        public string Property
        {
            get => tokenString;
            set
            {
                tokenString = value;
                NotifyStateChanged();
            }
        }*/

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
