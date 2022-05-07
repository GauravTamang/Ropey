using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ropey.Models
{
    [Table("Actor")]
    public partial class Actor
    {
        [Key]
        public int ActorNumber { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string ActorFirstName { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string ActorSurName { get; set; } = null!;
    }
}
