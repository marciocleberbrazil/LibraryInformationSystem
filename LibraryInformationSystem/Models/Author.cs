using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LibraryInformationSystem.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [DisplayName("Author Name")]
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}