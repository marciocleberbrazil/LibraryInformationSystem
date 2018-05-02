using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryInformationSystem.Models
{
    public class Access
    {
        public int AccessId { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReserved { get; set; }

        public int BorrowerId { get; set; }
        public virtual Borrower Borrower { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}