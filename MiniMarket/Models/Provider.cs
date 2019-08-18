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
        [Display(Name = "Nombre del Proveedor")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Numero de Nit")]
        public string Nit { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    

    }
}