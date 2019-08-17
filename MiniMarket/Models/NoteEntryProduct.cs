using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class NoteEntryProduct
    {

        public int Id { get; set; }
        [Display(Name = "Nro Nota Entrada")]
        public int NoteEntryID { get; set; }
        public virtual NoteEntry NoteEntry { get; set; }
        [Display(Name = "Nombre Producto")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

    }
}