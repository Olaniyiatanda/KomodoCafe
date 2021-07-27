using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01Repo
{
    public class MenuItems
    {
        //POCO
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> ListOfIngredients { get; set; } = new List<string>();
        public double Price { get; set; }

        public MenuItems() { }
        public MenuItems(int mealNumber,string mealName,string mealDescription,List<string> listOfIngredients,double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            Price = price;
        }

    }
}
