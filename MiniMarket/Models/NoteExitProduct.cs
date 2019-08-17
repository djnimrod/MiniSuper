using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class NoteExitProduct
    {

        public int Id { get; set; }

        public int NoteExitID { get; set; }
        public virtual NoteExit NoteExit { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}