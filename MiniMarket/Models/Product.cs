using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Precio { get; set; }
        [Required]
        public DateTime FechaVencimiento { get; set; }

        public string Foto { get; set; }


        // relations

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int UnitID { get; set; }
        public virtual Unit Unit { get; set; }

        public int ProviderID { get; set; }
        public virtual Provider Provider { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }


    }
}