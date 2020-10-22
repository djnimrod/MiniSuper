using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniMarket.Controllers;
using MiniMarket.Models;

namespace TestProjectMiniSuper
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //}

       
        public void TestSuma() {
            //arrange
            ProductsController1 cp = new ProductsController1();
            //act
            int val1 = 3;
            int val2 = 4;
            int resultado = val1+val2;
            
            int currentResult = cp.Sum(val1, val2);
            //asert
            Assert.IsTrue(currentResult == resultado,"Valor de suma Incorrecta");
        }
        [TestMethod]
        public void TestExisteProducto() {
            //arrange
            Product p = new Product();
            ProductsController cp = new ProductsController();
            //act
            p.Nombre = "Cerveza";
            p.Precio = 15;

            Product res= cp.BuscarProductoByNombre(p.Nombre);
            //asert
            Assert.IsTrue(res.Nombre == p.Nombre, "No existe el producto");
        }

        [TestMethod]
        public void TestAumentarProducto() {
            //arrange
            NoteEntryProductsController nep = new NoteEntryProductsController();
            // act
            NoteEntryProduct nt = new NoteEntryProduct();
            InventoriesController ic = new InventoriesController();
            nt.ProductID = 1;
            nt.Cantidad = 100;
            int existencia = ic.CantidadByProducto(nt.ProductID);

          //  nep.ActualizarInventario(nt.ProductID,nt.Cantidad);
            int actual = ic.CantidadByProducto(nt.ProductID);
            Assert.IsTrue(existencia == actual, "no se pudo actualizar el inventario");
            
        }

        [TestMethod]
        public void TestRestarProducto() {
            //arrange
            NoteExitProductsController nep = new NoteExitProductsController();
            // act
            NoteExitProduct nt = new NoteExitProduct();
            InventoriesController ic = new InventoriesController();
            nt.ProductID = 1;
            nt.Cantidad = 100;
            int existencia = ic.CantidadByProducto(nt.ProductID);

            
            int actual = ic.CantidadByProducto(nt.ProductID);
            Assert.IsTrue(existencia -nt.Cantidad == actual, "no se pudo actualizar el inventario");

        }

        public void TestExisteProductobyId() {
            //arrange
            Product p = new Product();
            ProductsController cp = new ProductsController();
            //act
            p.Id = 1;
            p.Nombre = "Cerveza";
            p.Precio = 15;

            Product res = cp.BuscarProductoById(p.Id);
            //asert
            Assert.IsTrue(res.Nombre == p.Nombre, "No existe el producto");
        }

        public void TestProductoMasAntiguo() {

            //arrange
            Product p = new Product();
            ProductsController cp = new ProductsController();
            //act
            p.Id = 1;
            p.Nombre = "Cerveza";
            p.Precio = 15;

            Product res = cp.BuscarProductoById(p.Id);
            //asert
            Assert.IsTrue(res.Nombre == p.Nombre, "No existe el producto");
        }

    }
}
