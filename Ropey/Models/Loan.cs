using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ropey.Models
{
    [Table("Loan")]
    public partial class Loan
    {
        [Key]
        public int LoanNumber { get; set; }
        public int? LoanTypeNumber { get; set; }
        public int? CopyNumber { get; set; }
        public int? MemberNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOut { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateDue { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateReturned { get; set; }

        [ForeignKey("CopyNumber")]
        [InverseProperty("Loans")]
        public virtual Dvdcopy? CopyNumberNavigation { get; set; }
        [ForeignKey("LoanTypeNumber")]
        [InverseProperty("Loans")]
        public virtual LoanType? LoanTypeNumberNavigation { get; set; }
        [ForeignKey("MemberNumber")]
        [InverseProperty("Loans")]
        public virtual Member? MemberNumberNavigation { get; set; }
    }
}
