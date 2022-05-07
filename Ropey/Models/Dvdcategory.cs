using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ropey.Models
{
    [Table("DVDCategory")]
    public partial class Dvdcategory
    {
        public Dvdcategory()
        {
            Dvdtitles = new HashSet<Dvdtitle>();
        }

        [Key]
        public int CategoryNumber { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? CategoryDescription { get; set; }
        public bool? AgeRestricted { get; set; }

        [InverseProperty("CategoryNumberNavigation")]
        public virtual ICollection<Dvdtitle> Dvdtitles { get; set; }
    }
}
