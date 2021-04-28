using System;

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

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
