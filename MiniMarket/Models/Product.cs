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
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public int Precio { get; set; }
        [Required]
        [Display(Name = "Fecha de vencimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaVencimiento { get; set; }
        [Display(Name = "Imagen del Producto")]
        public string Foto { get; set; }

        [Display(Name ="Imagen Qr del Producto")]
        public string ImagenQr { set; get; }

        // relations
        [Display(Name = "Nombre de Categoria")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Display(Name = "Tipo de Unidad")]
        public int UnitID { get; set; }
        public virtual Unit Unit { get; set; }
        [Display(Name = "Nombre del Proveedor")]
        public int ProviderID { get; set; }
        public virtual Provider Provider { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }

        // ** // 
        public virtual ICollection<NoteEntryProduct> NoteEntryProducts { get; set; }

    }
}