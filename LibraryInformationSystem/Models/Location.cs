using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LibraryInformationSystem.Models
{
    public class Location
    {
        [DisplayName("Location COD")]
        public string LocationId { get; set; }

        [DisplayName("Location Name")]
        public string Name { get; set; }
        public virtual List<Borrower> Borrowers { get; set; }
    }
}