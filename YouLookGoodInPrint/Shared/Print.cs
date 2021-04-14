using System;
using System.ComponentModel.DataAnnotations;

namespace YouLookGoodInPrint.Shared
{
    public class Print
    {
        [Key]
        public string Id { get; set; }


        public string Author { get; set; }

        public DateTime PrintDate { get; set; }

        public string Orientation { get; set; }

        public string Color { get; set; }

        public int Number { get; set; }

        public Print(string Id, string author, string orientation, string color, int number)
        {
            this.Id = Id;
            this.Author = author;
            this.PrintDate = DateTime.Now;
            this.Orientation = orientation;
            this.Color = color;
            this.Number = number;

        }
    }
}
