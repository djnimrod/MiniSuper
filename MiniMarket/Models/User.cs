using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string NameUser { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<NoteEntry> NoteEntries { get; set; }

        public virtual ICollection<NoteExit> NoteExits { get; set; }

    }

}