using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class Unit
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre de Unidad")]
        public string Nombre { get; set; }


        public virtual ICollection<Product> Products { get; set; }

    }
}