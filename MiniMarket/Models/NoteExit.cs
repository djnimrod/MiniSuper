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
        [Display(Name = "Observacion")]
        public string Observacion { get; set; }
        [Required]
        [Display(Name = "Fecha de Salida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaSalida { get; set; }
        [Required]
        [Display(Name = "Encargado de Almacen")]
        public string Encargado { get; set; }

        //relations
        public virtual ICollection<NoteEntryProduct> NoteEntryProducts { get; set; }
        [Display(Name = "Recibido por")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}