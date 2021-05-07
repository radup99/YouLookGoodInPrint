using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using YouLookGoodInPrint.Server.Data;

namespace YouLookGoodInPrint.Server.Entities
{
    public class TokenList
    {
        private Dictionary<string, string> _tokenDict = new Dictionary<string, string>();

        public TokenList(Database database)
        {
            UserDataAccess userDataAccess = new UserDataAccess(database);
            List<string> usernames = userDataAccess.GetAllUsernames();

            foreach (string username in usernames)
            {
                string token = GenerateToken();
                _tokenDict.Add(token, username);
            }
        }

        public void AddUser(string username)
        {
            string token = GenerateToken();
            _tokenDict.Add(token, username);
        }

        public string GetToken(string username)
        {
            foreach (KeyValuePair<string, string> entry in _tokenDict)
            {
                if (entry.Value == username)
                    return entry.Key;
            }

            return "null";
        }

        public void ChangeToken(string username, string newToken)
        {
            foreach (KeyValuePair<string, string> entry in _tokenDict)
            {
                if (entry.Value == username)
                {
                    _tokenDict.Remove(entry.Key);
                    _tokenDict.Add(newToken, username);
                }
            }
        }

        public string GetUsername(string token)
        {
            return _tokenDict[token];
        }

        public bool IsTokenValid(string username, string token)
        {
            foreach (KeyValuePair<string, string> entry in _tokenDict)
            {
                if (entry.Key == token)
                {
                    if (entry.Value == username)
                        return true;
                    return false;
                }  
            }
            return false;
        }

        private string GenerateToken()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var token = new char[20];

            for (int i = 0; i < 19; i++)
            {
                int index = SecureRandInt(0, chars.Length-1);
                token[i] = chars[index];
            }

            return new string(token);
        }

        private int SecureRandInt(int min, int max)
        {
            RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();
            uint scale = uint.MaxValue;

            while (scale == uint.MaxValue)
            {
                byte[] four_bytes = new byte[4];
                Rand.GetBytes(four_bytes);

                scale = BitConverter.ToUInt32(four_bytes, 0);
            }

            return (int)(min + (max - min) * (scale / (double)uint.MaxValue));
        }
    }
}
