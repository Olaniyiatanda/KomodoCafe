using Challenge01Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoTest
{
    [TestClass]
    public class MenuItemTest
    {
       
        [TestMethod]
        public void SetMenuList() 
        {
            MenuItems items = new MenuItems();
            items.MealName = "Fries";

            string expected = "Fries";
            string actual = items.MealName;

            Assert.AreEqual(expected, actual);

        }
    }
}
 