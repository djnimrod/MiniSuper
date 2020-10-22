using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UnitTestSelenium
{
    public class Locator
    {
        public static By GetTheBySelector(Enum controlName)
        {
            ReturnBySelector().TryGetValue(controlName, out By by);
            return by;
        }
        internal static Dictionary<Enum, By> ReturnBySelector()
        {
            return new Dictionary<Enum, By>()
            {
                {TextBox.Producto_Title,By.CssSelector("input[class='gLFyf gsfi']") },
            };
        }
        public enum TextBox
        {
            Producto_Title,
        }

    }
}
