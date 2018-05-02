using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryInformationSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime Published { get; set; }
        public Decimal PurchasePrice { get; set; }
        public Decimal CurrentPrice { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Publisher> Publishers { get; set; }

        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Publishers = new HashSet<Publisher>();
        }
    }
}