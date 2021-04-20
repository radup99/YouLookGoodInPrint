namespace YouLookGoodInPrint.Shared
{
    public class EntityData<T>
    {
        public T Item { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public string Option { get; set; }

        public EntityData(T item, string username, string token, string option)
        {
            Item = item;
            Username = username;
            Token = token;
            Option = option;
        }
    }
}
