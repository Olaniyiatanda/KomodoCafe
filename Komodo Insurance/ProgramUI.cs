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
                        ListOfBadges();

                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine(" ");
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
            Console.Clear();
            Console.WriteLine("What Badge Number are you updating?:");
            int input = int.Parse( Console.ReadLine());
            var badge = _repo.GetBadgeByBadgeId(input);
            
            string response = string.Join("$ ", badge.Value);
            Console.WriteLine($"{badge.Key} has access to doors : {response}\n" +
                $"\n");
            Console.WriteLine("what would you like to do, Select the right option:?\n" +
                "\t\t 1.Remove Door\n" +
                "\t\t 2.Add a doo");
            string response3 = Console.ReadLine();
            switch (response3)
            {
                case "1":
                    Console.Write("What door do you want to remove?:");
                    string response4 = Console.ReadLine();
                    if (badge.Value.Contains(response4))
                    {
                        int number = badge.Value.Count;
                        if (number == 0)
                        {
                            Console.WriteLine($"Badge Number {badge.Key}  do not have any door associated to it");
                        }
                        badge.Value.Remove(response4);
                        Console.WriteLine("Door removed");
                        string response5 = string.Join("$ ", badge.Value);
                       
                        Console.WriteLine($"{badge.Key} has access to doors : {response5}\n" +
                        $"\n");
                    }
                    else
                    {
                        Console.WriteLine($"This door:{response3} is not connected to this badge");
                    }
                    break;
                case "2":
                    Console.WriteLine("What door do you want to add");
                    string input1 = Console.ReadLine();
                    badge.Value.Add(input1);
                    Console.WriteLine("door added successfully");

                    string input2 = string.Join("$ ", badge.Value);

                    Console.WriteLine($"{badge.Key} has access to doors : {input2}\n" +
                    $"\n");
                    break;

                default:
                    Console.WriteLine("Please enter a valid Number");
                    break;
            }


        }

        private  void ListOfBadges()
        {
            Console.Clear();
            var Badges = _repo.GetDictionary();
            Console.WriteLine($"{"Badge#",-10}{"Door Access"}");
            foreach (var item in Badges)

            {
              
                Console.WriteLine($"{item.Key,-10} {string.Join(",", item.Value)}");
            }
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
            BadgeProperties badge1 = new BadgeProperties(1235,  new List<string> { "Door3" }, "DoorNAME1");

            _repo.Addbadge(badge1);

        }



    }
}
