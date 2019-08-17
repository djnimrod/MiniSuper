using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class Provider
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Nit { get; set; }
        [Required]
        public string Direccion { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    

    }
}