using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Configuration;

namespace UnitTestSelenium
{
    [TestClass]
  //  [TestCategoryBase="Productos"]
    public class UnitTest1 : ClsBase
    {
        [TestMethod]
        [TestCategory("Producto")]
        public void VerGoogle()
        {
            WebDriverBase webDriverBase = new WebDriverBase();
            webDriverBase.InstanceChrome("https://www.google.com");
            webDriverBase.SetText(By.CssSelector("input[class='gLFyf gsfi']"), "Hola");
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.TextBox.Producto_Title), "Second with locator");
            webDriverBase.CloseBrowser();
        }

        [TestMethod]
        [TestCategory("Prueba")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "Configuration.csv", "Configuration#csv", DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
          //  var dd = TestContext.DataRow["url"].ToString();
            WebDriverBase webDriverBase = new WebDriverBase();
            webDriverBase.InstanceChrome("https://www.google.com");
            webDriverBase.SetText(By.CssSelector("input[class='gLFyf gsfi']"), "Hola");
            webDriverBase.SetText(Locator.GetTheBySelector(Locator.TextBox.Producto_Title), "Second with locator");
            webDriverBase.MoveToElement(Locator.GetTheBySelector(Locator.TextBox.Producto_Title));
            webDriverBase.CloseBrowser();
        }


        [TestCategory("Categoria")]
        [TestMethod]
        public void InsertarCategoria()
        {
            //Pasos
            //1.-inicializar web Driver
            //2.-abrir instancia de Chrome
            //3.- ir a la pagina principal
            //4.- verificar que la pagina cargue correctamente
            //5.- hacer click Productos del menu
                // 6.- verificar que exista categoria
            // 7.- hacer click a Categorias
            // 8.- hacer click a Create
            //  
            //9.- abrir pagina
            //dirigirse a la pagina de 
        }
    }
}
