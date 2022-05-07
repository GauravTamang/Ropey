using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ropey.Models
{
    [Table("Member")]
    public partial class Member
    {
        public Member()
        {
            Loans = new HashSet<Loan>();
        }

        [Key]
        public int MemberNumber { get; set; }
        public int? MembershipCategoryNumber { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? MembershipLastName { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? MembershipFirstName { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? MemberAddress { get; set; }
        [Column(TypeName = "date")]
        public DateTime? MemberDateofBirth { get; set; }

        [ForeignKey("MembershipCategoryNumber")]
        [InverseProperty("Members")]
        public virtual MembershipCategory? MembershipCategoryNumberNavigation { get; set; }
        [InverseProperty("MemberNumberNavigation")]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
