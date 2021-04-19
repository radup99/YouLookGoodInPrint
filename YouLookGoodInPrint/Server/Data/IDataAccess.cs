using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouLookGoodInPrint.Server.Data
{
    interface IDataAccess<T>
    {
        public void Add(T t);
        public void Remove(string id);
        public T Get(string id);
        public bool Exists(string id);

    }
}
