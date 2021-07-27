using Challenge01Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01Console
{
    class ProgramUI
    {
        
        MenuRepository _menu1 = new MenuRepository();
 

        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display our options 
                Console.WriteLine("Welcome to Komodo Cafe\n" +
                    "Select from the options:\n" +
                    "1. Add meal to Menu List\n" +
                    "2. Veiw list of Menu\n" +
                    "3. Veiw meal by meal name\n" +
                    "4. DeleteMeal\n" +
                    "5 Exit");

                //Get the user's input 
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddMealToList();
                        break;
                    case "2":
                        ViewListOfMenu();
                        break;
                    case "3":
                        ViewMealByMealName();
                        break;
                    case "4":
                        DeleteMeal();
                        break;
                    case "5":
                        keepRunning = false; 
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        Console.ReadLine();
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
                //Evaluate the user;s input and act according

                //Enter meal number 
            }

        }
        private void AddMealToList()
        {
            MenuItems menu = new MenuItems();
            Console.WriteLine("Enter the meal number");
            menu.MealNumber = int.Parse (Console.ReadLine());
            Console.WriteLine("Enter the meal name");
            menu.MealName = Console.ReadLine();
            Console.WriteLine("Enter menu Description");
            menu.MealDescription = Console.ReadLine();
            Console.WriteLine("Enter the price for meal");
            menu.Price = double.Parse(Console.ReadLine());

            bool keeprunning = true;
            while (keeprunning)
            {
                Console.WriteLine("Enter ingredients or No to Exit");
                string ingredients = Console.ReadLine();
                if (ingredients.ToLower() =="no" )
                {
                    keeprunning = false;
                }
                else
                {
                    menu.ListOfIngredients.Add(ingredients);
                }
                
            }
            _menu1.AddMenuToList(menu);

            Console.WriteLine("meal added succesfully");
            




        }
        private void ViewListOfMenu()
        {
            List<MenuItems> listOfMenuItems = _menu1.ReadMenuitems();
           foreach(MenuItems menu in listOfMenuItems)
            {
                Console.WriteLine($"{menu.MealNumber}, {menu.MealName}");
            }
            
            
        }
        private void ViewMealByMealName()
         
        {
            Console.WriteLine("Enter meal Number");
            int mealNumber = int.Parse(Console.ReadLine());
            MenuItems menu = _menu1.GetMenuByNumber(mealNumber); 
            if (menu is null)
            {
                Console.WriteLine($"There is no Menu Item with this meal number:{mealNumber}");
            }
            else
            {
                Console.WriteLine($"Menu:{menu.MealName}, price:${menu.Price}");
            }
        }
        private void DeleteMeal()
        {
            Console.WriteLine("Enter meal Number for the Menu you want to delete");
            int mealNumber = int.Parse(Console.ReadLine());
           bool Isdeleted = _menu1.DelectMenuFromList(mealNumber);
            if (Isdeleted is true)
            {
                Console.WriteLine("Menu successfully deleted");
            }
            else
            {
                Console.WriteLine("Menu was unsucessfully delected");
            }

        }
    }

}
