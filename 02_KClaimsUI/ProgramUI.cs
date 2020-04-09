using _02_KClaims;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaimsUI
{
    public class ProgramUI
    {
        ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            ClaimSeed();
            RunMenu();
        }
        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Weclome to Komodo Claims Department, Please select you option \n" +
                    "1. See All Claims \n" +
                    "2. Review Next Claim \n" +
                    "3. Enter New Claim\n" +
                    "4. Exit");
                int userinput = int.Parse(Console.ReadLine());
                switch (userinput)
                {
                    case 1:
                        Console.Clear();
                        ShowallClaims();
                        Console.WriteLine("Press any key to go to main menu...");
                        Console.ReadKey();

                        break;
                    case 2:
                        ReviewNextClaim();
                        Console.ReadLine();
                        break;
                    case 3:
                        EnterNewClaim();
                        Console.ReadLine();

                        break;
                    case 4:
                        isRunning = false;
                        Console.WriteLine("Thank You and Come Agian");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Please select the right option");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void ShowallClaims()
        {
            Queue<ClaimContent> claimList = _claimRepo.GetListOfClaims();
            foreach (ClaimContent claimContent in claimList)
            {
                Console.WriteLine($"ClaimID- {claimContent.ClaimID}\n" +
                    $"Type- {claimContent.TypeOfClaim}\n" +
                    $"Description-{claimContent.Description}\n" +
                    $"Claim Amount-{claimContent.ClaimAmount}\n"+
                    $"Date Of Accident-{claimContent.DateOfAccident}\n"+
                    $"Date Of Claim-{claimContent.DateOfClaim}\n"+
                    $"IsValid- {claimContent.IsValid}");
            }
        }
        public void ReviewNextClaim()
        {
            Queue<ClaimContent> queueList = _claimRepo.GetListOfClaims();
            Console.WriteLine("Following are the details about next claim-");
            Console.WriteLine($"Claim ID- {queueList.Peek().ClaimID}");
            Console.WriteLine($"Claim Type: {queueList.Peek().TypeOfClaim}");
            Console.WriteLine($"Claim Description: {queueList.Peek().Description}");
            Console.WriteLine($"Claim Amount: ${queueList.Peek().ClaimAmount}");
            Console.WriteLine($"Claim Incident Date: {queueList.Peek().DateOfAccident}");
            Console.WriteLine($"Claim Date: {queueList.Peek().DateOfClaim}");
            Console.WriteLine($"Claim Is Valid ? : {queueList.Peek().IsValid}");

            Console.WriteLine("Do you waned to deal with current Claim?\n" +
                "Enter Y for Yes\n" +
                "Enter N for No");
            string userInput = Console.ReadLine();
            if (userInput == "Y")
            {
                queueList.Dequeue();
            }
            else
            {
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadLine();
            }
        }
        public void EnterNewClaim()
        {
            ClaimContent newClaim = new ClaimContent();
            Console.WriteLine("Please enter the Claim ID: ");
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please select the number for your Claim Type :\n" +
              "1 - Car\n" +
              "2 - House\n" +
              "3 - Theft");
            newClaim.TypeOfClaim = (ClaimType)(int.Parse(Console.ReadLine()));

            Console.WriteLine("Please enter the Claim Description: ");
            newClaim.Description = (Console.ReadLine());

            Console.WriteLine("Please enter the Claim Amount: ");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Claim Incident Date. In following format: YYYY,MM,DD ");
            newClaim.DateOfAccident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please enter the Claim Reported Date. In following format: YYYY,MM,DD ");
            newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            string isClaimValid;
            if (_claimRepo.IsValid(newClaim) == true)
            {
                isClaimValid = "Valid";
            }
            else
            {
                isClaimValid = "Not Valid";
            }
           
            _claimRepo.EnterNewClaim(newClaim);
            Console.WriteLine($"\nClaim ID: {newClaim.ClaimID}\n" +
            $"Claim Type: {newClaim.TypeOfClaim}\n" +
            $"Claim Description: {newClaim.Description}\n" +
            $"Claim Amount: {newClaim.ClaimAmount}\n" +
            $"Incident Date: {newClaim.DateOfAccident}\n" +
            $"Claim Date: {newClaim.DateOfClaim}\n" +
            $"This claim is: {isClaimValid}\n");
            Console.WriteLine("Your claim has been added. Press Any Key to go to main menu....");
        }
        private void ClaimSeed()
        {
            ClaimContent claimOne = new ClaimContent(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
           
            ClaimContent claimTwo = new ClaimContent(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 18), true);
           
            ClaimContent claimThree = new ClaimContent(3, ClaimType.Theft, "Stolen pancakes", 1000.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);
           

            _claimRepo.EnterNewClaim(claimOne);
            _claimRepo.EnterNewClaim(claimTwo);
            _claimRepo.EnterNewClaim(claimThree);
        }
            
    }
   
}
