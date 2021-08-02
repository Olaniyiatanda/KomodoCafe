using ClaimRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_ClaimsConsole
{
    class ProgramUI
    {
        ClaimsRepository _repo = new ClaimsRepository();
        private bool yes;

        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display our option to the user 
                Console.WriteLine("Welcome to Komodo Claims:\n" +
                    " Select from the following options\n" +
                    "1: View all claims\n" +
                    "2: Take care of next claim\n" +
                    "3: Enter a new claim\n" +
                    "4: Exit");
                //Get the user's input
                string input = Console.ReadLine();
                // Evaluate the user's input and act accordingly
                switch (input)

               
                {
                    case "1":
                        GetClaimsList();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        AddClaimToList();
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
                Console.WriteLine("please press any key to continue..");
                Console.ReadLine();
                Console.Clear();
            }


        }
        //View all Claims
        private void GetClaimsList()
        {
            Console.WriteLine($"{"ClaimId",-10}{"Type Of Claim",-20} {"Description",-25}{"Amount",-8}{"DateofIncident",-15} {"DateofClaim",-15}{"IsValid"}");
            var Claimlist = _repo.GetClaimsQueue().ToList();
            foreach (var item in Claimlist)
            {
                Console.WriteLine($"{item.ClaimId,-10} {item.ClaimType,-20} {item.Description,-25} ${item.ClaimAmount.ToString("00"),-8} {item.DateOfIncident.ToString("d"),-15}{item.DateOfClaim.ToString("d"),-15}{item.IsValid}");
            }
            //ClaimId
            

            //ClaimType

            //Claim description
            Console.WriteLine();

        }
        //Take care of next claim
        public void TakeCareOfNextClaim()
        {
            var claim = _repo.viewNextClaim();
            Console.WriteLine($"claimId:{claim.ClaimId}\n" +
                $"claimType:{claim.ClaimType}\n" +
                $"description:{claim.Description}\n" +
                $"date of Accident:{claim.DateOfIncident.ToString("d")}\n" +
                $"date of claim: {claim.DateOfClaim.ToString("d")}\n" +
                $"isValid:{claim.IsValid}");


            Console.ReadLine();
            Console.WriteLine("Do you want to deal with this claim now?(y/n)");
            if (yes)
            {
                _repo.viewNextClaim();
            }
            else
            {
                Console.WriteLine("Return to main menu");
            }


 
            
            
             

           








        }
        //Enter a new claim
        public void AddClaimToList()
        {
            //ClaimID
            ClaimsProperties newClaims = new ClaimsProperties();
            Console.WriteLine("Enter ClaimID");
            newClaims.ClaimId = int.Parse(Console.ReadLine());

            //ClaimType
            Console.WriteLine("Enter type number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");

            string claimsAsString = Console.ReadLine();
            int claimsAsint = int.Parse(claimsAsString);
            newClaims.ClaimType = (TypeOfClaim)claimsAsint;

            //Description
            Console.WriteLine("Enter a claim description");
            newClaims.Description = Console.ReadLine();

            //Claim Amount 
            Console.WriteLine("Amount of Damages");
            newClaims.ClaimAmount = double.Parse(Console.ReadLine());
            //Date of incident 
            Console.WriteLine("Date of Accident: mm//dd//Year");
            newClaims.DateOfIncident = DateTime.Parse(Console.ReadLine());
            //Date of claim
            Console.WriteLine("Date of claim: mm/dd/year");
            newClaims.DateOfClaim = DateTime.Parse(Console.ReadLine());
            //IsValid
            //Console.WriteLine("Is this valid? (y/n)");
            //string isValidString = Console.ReadLine().ToLower();

            _repo.AddClaimsToList(newClaims);

        }
        

        

        //Exit 
    }
}
