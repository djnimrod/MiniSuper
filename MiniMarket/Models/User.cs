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
        [Display(Name = "Nombre de Usuario")]
        public string NameUser { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public virtual ICollection<NoteEntry> NoteEntries { get; set; }

        public virtual ICollection<NoteExit> NoteExits { get; set; }

    }

}