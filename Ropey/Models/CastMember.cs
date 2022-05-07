using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ropey.Models
{
    [Keyless]
    [Table("CastMember")]
    public partial class CastMember
    {
        public int? ActorNumber { get; set; }
        [Column("DVDNumber")]
        public int? Dvdnumber { get; set; }

        [ForeignKey("ActorNumber")]
        public virtual Actor? ActorNumberNavigation { get; set; }
        [ForeignKey("Dvdnumber")]
        public virtual Dvdtitle? DvdnumberNavigation { get; set; }
    }
}
