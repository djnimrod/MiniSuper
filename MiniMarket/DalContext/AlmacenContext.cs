using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MiniMarket.Models;

namespace MiniMarket.DalContext
{
    public class AlmacenContext : DbContext
    {

        public DbSet<Category> Categories { set; get; }
        public DbSet<Unit> Units { set; get; }
        public DbSet<Provider> Providers { set; get; }
        public DbSet<Inventory> Inventories { set; get; }
        public DbSet<Product> Products { set; get; }

        public System.Data.Entity.DbSet<MiniMarket.Models.NoteEntry> NoteEntries { get; set; }

        public System.Data.Entity.DbSet<MiniMarket.Models.NoteEntryProduct> NoteEntryProducts { get; set; }

        public System.Data.Entity.DbSet<MiniMarket.Models.User> Users { get; set; }
    }
}