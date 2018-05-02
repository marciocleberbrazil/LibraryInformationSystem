using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryInformationSystem.Models
{
    public class Location
    {
        public string LocationId { get; set; }
        public string Name { get; set; }
        public virtual List<Borrower> Borrowers { get; set; }
    }
}