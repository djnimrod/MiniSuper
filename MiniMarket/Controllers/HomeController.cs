using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniMarket.DalContext;
using MiniMarket.Models;

namespace MiniMarket.Controllers
{
    public class HomeController : Controller
    {
        private AlmacenContext db = new AlmacenContext();
        public ActionResult Index()
        {
            //ViewBag.Inventario = db.Inventories.Where(b => b.ProductID =  b => b.Product.Id)
            var products = (from p in db.Products
                           from x in db.Inventories
                           where p.Id == x.ProductID
                           orderby x.Cantidad
                           select p).Take(3);

            return View(products.ToList().AsEnumerable());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}