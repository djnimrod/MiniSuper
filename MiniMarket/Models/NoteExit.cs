using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class NoteExit
    {
        public int Id { get; set; }
        [Required]
        public string Observacion { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; }
        [Required]
        public string Encargado { get; set; }

        //relations
        public virtual ICollection<NoteEntryProduct> NoteEntryProducts { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}