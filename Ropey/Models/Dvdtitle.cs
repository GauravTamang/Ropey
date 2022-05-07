using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ropey.Models
{
    [Table("DVDTitle")]
    public partial class Dvdtitle
    {
        public Dvdtitle()
        {
            Dvdcopies = new HashSet<Dvdcopy>();
        }

        [Key]
        [Column("DVDNumber")]
        public int Dvdnumber { get; set; }
        public int? CategoryNumber { get; set; }
        public int? StudioNumber { get; set; }
        public int? ProducerNumber { get; set; }
        [Column("DVDTitle")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Dvdtitle1 { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateReleased { get; set; }
        public int? StandardCharge { get; set; }
        public int? PenaltyCharge { get; set; }

        [ForeignKey("CategoryNumber")]
        [InverseProperty("Dvdtitles")]
        public virtual Dvdcategory? CategoryNumberNavigation { get; set; }
        [ForeignKey("ProducerNumber")]
        [InverseProperty("Dvdtitles")]
        public virtual Producer? ProducerNumberNavigation { get; set; }
        [ForeignKey("StudioNumber")]
        [InverseProperty("Dvdtitles")]
        public virtual Studio? StudioNumberNavigation { get; set; }
        [InverseProperty("DvdnumberNavigation")]
        public virtual ICollection<Dvdcopy> Dvdcopies { get; set; }
    }
}
