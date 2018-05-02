using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LibraryInformationSystem.Models
{
    public class Borrower
    {
        public int BorrowerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }

        [DisplayName("Suburbs")]
        public string Address2 { get; set; }
        public string LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}