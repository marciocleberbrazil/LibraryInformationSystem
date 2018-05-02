using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryInformationSystem.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            this.Books = new HashSet<Book>();
        }
    }
}