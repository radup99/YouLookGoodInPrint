using System;
using System.ComponentModel.DataAnnotations;

namespace YouLookGoodInPrint.Shared
{
    public class Document
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public Document(string name, string author, string content)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Author = author;
            this.Content = content;
            this.CreationDate = DateTime.Now;
        }
    }
}
