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
        public int NoteEntryID { get; set; }
        public virtual NoteEntry NoteEntry { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int Cantidad { get; set; }

    }
}