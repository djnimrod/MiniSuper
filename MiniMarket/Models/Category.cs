using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tipo de Categoria")]
        public string TipoCategoria { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    
    }
}