using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ropey.Models
{
    public partial class User
    {
        [Key]
        public int UserNumber { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? UserName { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? UserType { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? UserPassword { get; set; }
    }
}
