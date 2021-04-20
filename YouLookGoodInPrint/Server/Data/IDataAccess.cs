namespace YouLookGoodInPrint.Server.Data
{
    interface IDataAccess<T>
    {
        public void Add(T item);
        public void Remove(string id);
        public T Get(string id);
        public bool Exists(string id);

    }
}
