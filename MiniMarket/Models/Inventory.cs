using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        //relations
        [Display(Name = "Nombre Producto")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

    }
}