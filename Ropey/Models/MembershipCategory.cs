using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ropey.Models
{
    [Table("MembershipCategory")]
    public partial class MembershipCategory
    {
        public MembershipCategory()
        {
            Members = new HashSet<Member>();
        }

        [Key]
        public int MembershipCategoryNumber { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? MembershipCategoryDescription { get; set; }
        public int? MembershipCategoryTotalLoans { get; set; }

        [InverseProperty("MembershipCategoryNumberNavigation")]
        public virtual ICollection<Member> Members { get; set; }
    }
}
