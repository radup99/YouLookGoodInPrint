namespace YouLookGoodInPrint.Shared
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Credentials(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

    }
}
