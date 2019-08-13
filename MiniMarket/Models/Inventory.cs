using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMarket.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }
        public int Stock { get; set; }

        //relations

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

    }
}