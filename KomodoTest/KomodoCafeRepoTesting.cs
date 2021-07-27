using Challenge01Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge01Repo.KomodoTest
{
  
    [TestClass]
    
    public class KomodoCafeRepoTesting
    {
        private MenuItems _repo;
        private MenuRepository _menu1;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItems();
            _menu1 = new MenuRepository();

            _menu1.AddMenuToList(_repo);
             
        }
        //AddMethod
        [TestMethod]

        public void AddItemsToMenu_shouldNotGetNull()
        {

          //Arrange
            MenuItems menu = new MenuItems();
            menu.MealName = "Tacos";
            MenuRepository repository = new MenuRepository();

            //Act
            repository.AddMenuToList(menu);
            MenuItems listFromMenu = repository.GetMenuByName("Tacos");
            //Assert
            Assert.IsNotNull(listFromMenu);


        }
        [TestMethod]
        public void DeleteMenu_ShouldReturnTrue()
        {
            bool deleteResult = _menu1.DelectMenuFromList(_repo.MealName);
            //Assert
            Assert.IsTrue(deleteResult);
        }
   

    }
}
 