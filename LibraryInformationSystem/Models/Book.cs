using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LibraryInformationSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string ISBN { get; set; }

        [DisplayName("Book Title")]
        public string Title { get; set; }
        public DateTime Published { get; set; }

        [DisplayName("Purchase Price")]
        public Decimal PurchasePrice { get; set; }

        [DisplayName("Current Price")]
        public Decimal CurrentPrice { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}