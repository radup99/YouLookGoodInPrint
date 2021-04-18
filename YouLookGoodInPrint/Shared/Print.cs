using System;
using System.ComponentModel.DataAnnotations;

namespace YouLookGoodInPrint.Shared
{
    public class Print
    {
        [Key]
        public string IdPrint { get; set; }
        public string IdDoc { get; set; }


        public string Author { get; set; }

        public DateTime PrintDate { get; set; }

        public string Orientation { get; set; }

        public string Color { get; set; }

        public int Number { get; set; }

        public Print(string idDoc, string author, string orientation, string color, int number)
        {
            this.IdPrint=Guid.NewGuid().ToString();
            this.IdDoc= idDoc;
            this.Author = author;
            this.PrintDate = DateTime.Now;
            this.Orientation = orientation;
            this.Color = color;
            this.Number = number;

        }
    }
}
