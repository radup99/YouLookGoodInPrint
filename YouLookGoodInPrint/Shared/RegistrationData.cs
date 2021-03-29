namespace YouLookGoodInPrint.Shared
{
    public class RegistrationData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }

        public RegistrationData(string username, string password, string realname, string email)
        {
            this.Username = username;
            this.Password = password;
            this.RealName = realname;
            this.Email = email;
        }
    }
}
