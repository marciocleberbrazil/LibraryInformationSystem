using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryInformationSystem.Models
{
    public class Borrower
    {
        public int BorrowerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}