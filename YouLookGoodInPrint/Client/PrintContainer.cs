using System.Collections.Generic;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Client
{
    public class PrintContainer
    {
        public List<Print> prints;

        public Print currentPrint = new Print("", "", "","",0);
        public void Clear()
        {
            prints = null;
        }

        public void selectPrint(Print print)
        {
            this.currentPrint = print;
        }
    }
}
