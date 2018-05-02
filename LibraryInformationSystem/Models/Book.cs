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

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}