namespace YouLookGoodInPrint.Shared
{
    public class DocumentData
    {
        public Document Document { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public string Option { get; set; }

        public DocumentData(Document document, string username, string token, string option)
        {
            Document = document;
            Username = username;
            Token = token;
            Option = option;
        }
    }
}
