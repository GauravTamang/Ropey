using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ropey.Models
{
    [Table("DVDCopy")]
    public partial class Dvdcopy
    {
        public Dvdcopy()
        {
            Loans = new HashSet<Loan>();
        }

        [Key]
        public int CopyNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DatePurchased { get; set; }
        [Column("DVDNumber")]
        public int? Dvdnumber { get; set; }

        [ForeignKey("Dvdnumber")]
        [InverseProperty("Dvdcopies")]
        public virtual Dvdtitle? DvdnumberNavigation { get; set; }
        [InverseProperty("CopyNumberNavigation")]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
