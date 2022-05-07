using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ropey.Models
{
    [Table("LoanType")]
    public partial class LoanType
    {
        public LoanType()
        {
            Loans = new HashSet<Loan>();
        }

        [Key]
        public int LoanTypeNumber { get; set; }
        [Column("LoanType")]
        [StringLength(255)]
        [Unicode(false)]
        public string? LoanType1 { get; set; }
        public int? LoanDuration { get; set; }

        [InverseProperty("LoanTypeNumberNavigation")]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
