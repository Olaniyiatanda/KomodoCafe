using Komodo_InsuranceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    public class ProgramUI
    {
        private BadgeRepository _repo = new BadgeRepository();
        public void Run()
        {
            Menu();
            SeedContent();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option from the Menu option:\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Addbadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":


                        break;
                    case "4":
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
            Console.WriteLine("Please Press any Key to continue............");
            Console.ReadKey();
            Console.Clear();


            }

        }
        private void Addbadge()
        {
            Console.Clear();
            BadgeProperties newBadge = new BadgeProperties();
            Console.WriteLine("What is the Number on the Badge?:");
            newBadge.BadgeId = int.Parse(Console.ReadLine());

            bool running = true;
            while (running)
            {

                Console.WriteLine("List the door that this Badge should access:");
                string response = Console.ReadLine();
                newBadge.DoorNames.Add(response);

                Console.WriteLine("Do you have any other door to be added to this badge, Enter Y/N:");
                string response1 = Console.ReadLine().ToUpper();

                if (response1 == "N")
                {
                    running = false;
                }



            }
            _repo.Addbadge(newBadge);
            Console.WriteLine("Badge added..............");
            Console.WriteLine(" ");

        }




        //Edit all badges


        private void UpdateBadge()
        {
            Console.WriteLine("What Badge Number are you updating?:");
            int input = int.Parse( Console.ReadLine());
            var badge = _repo.GetBadgeByBadgeId(input);
            string response = string.Join("$ ", badge.Value);
            Console.WriteLine($"{badge.Key} has access to doors : {response}");


        }




        //List all badges

        //private void GetDictionary()
        //{


        //    Console.WriteLine("All Badges");
        //    foreach (KeyValuePair<int, List<string>> badge)
        //    {
        //        Console.WriteLine($"Badge: { badge.Key}");

        //        foreach (string door in badge.Value)
        //            Console.WriteLine(door);
        //        Console.WriteLine("Press any key to return to main menu");
        //        Console.ReadLine();

        //    }


        //}


        public void SeedContent()
        {
            BadgeProperties badge1 = new BadgeProperties(1235, new List<string> { "Door3" }, "DoorNAME1");

            _repo.Addbadge(badge1);

        }



    }
}
