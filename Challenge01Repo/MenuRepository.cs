using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01Repo
{
    public class MenuRepository
    {
        private List<MenuItems> _listOfMenu = new List<MenuItems>();
        //Create
        public void AddMenuToList(MenuItems items)
        {
            _listOfMenu.Add(items);
        }
        //Read 
        public List<MenuItems> ReadMenuitems()
        {
            return _listOfMenu;
        }
        //Delete
        public bool DelectMenuFromList(int mealnumber)
        {
            MenuItems items = GetMenuByNumber(mealnumber);

            if(items == null)
            {
                return false;
            }
            int initialCount = _listOfMenu.Count;
            _listOfMenu.Remove(items);
            if (initialCount > _listOfMenu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper Method
        public MenuItems GetMenuByNumber(int mealnumber)
        {
           foreach (MenuItems items in _listOfMenu)
            {
                if(items.MealNumber == mealnumber)
                {
                    return items;
                }
                
            }
            return null;
        }

    }
}
