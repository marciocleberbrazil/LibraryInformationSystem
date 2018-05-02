using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LibraryInformationSystem.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        [DisplayName("Publisher Name")]
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}