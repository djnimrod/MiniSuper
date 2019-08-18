using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Comentario")]
        [StringLength(120)]
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }

    }
}