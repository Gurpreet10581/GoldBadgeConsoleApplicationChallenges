﻿using _03_KBadges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KBadgesUI
{
    public class ProgramUI
    {
        BadgesRepo _repo = new BadgesRepo();

        public void Run()
        {
            BadgeSeed();
            RunMenu();
        }
        public void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcom to Badge System\n" +
                    "1. Create a new badge\n" +
                   "2. Update doors on an existing badge\n" +
                    "3. Delete a badge from the list\n" +
                    "4. Show list of all badge numbers and their door access\n" +
                    "5. Exit.");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        CreateNewBadge();
                        break;
                    case 2:
                        UpdateDoorAccess();
                        break;
                    case 3:
                        DeleteBadge();
                        break;
                    case 4:
                        ListOfBadgesAndDoors();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please select the rigth option");
                        break;
                }

            }

        }
        public void CreateNewBadge()
        {
            Console.Clear();

            int badgeId = 0;
            List<string> doors = new List<string>();

            Console.WriteLine("What is the badge number?");
            badgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("Please advise the door that this badge can access?");
            string doorInput = Console.ReadLine();
            doors.Add(doorInput);

            Console.WriteLine("Your door access has been added");
            Console.WriteLine("Do you waned to add another door?\n" +
                "Enter y for Yes\n" +
                "Enter n for No");
            string userInput = Console.ReadLine().ToLower();
            
            if (userInput == "y")
            {
                CreateNewBadge();
            }
            else
            {
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadLine();
            }
            Console.ReadKey();
            BadgesContent newBadge = new BadgesContent(badgeId, doors);
            _repo.CreateNewBadge(newBadge);

        }
        public void UpdateDoorAccess()
        {
            CreateNewBadge();
        }

        public void DeleteBadge()
        {
            Console.Clear();

            Dictionary<int, List<string>> badgeDict = _repo.ListOfBadgesAndDoors();
            Console.WriteLine("Enter the BadgeId that you are wanting to remove");
            int userInput = int.Parse(Console.ReadLine());

            foreach (var badgeId in badgeDict)
            {
                if (userInput == badgeId.Key)
                {
                    _repo.GetDoorsByBadgeId(badgeId.Key);
                    break;
                }
            }
        }

        public void ListOfBadgesAndDoors()
        {

            Console.Clear();

            Dictionary<int, List<string>> badgeDict = _repo.ListOfBadgesAndDoors();
            foreach (KeyValuePair<int, List<string>> showBadge in badgeDict)
            {
                Console.Write($"Badge Id- {showBadge.Key}\n");
                Console.Write("Accessible Doors- ");

                foreach (string dictList in showBadge.Value)
                {
                    Console.Write($"{dictList}\n");
                }

            }

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
        }

        public void BadgeSeed()
        {
            BadgesContent badgeOne = new BadgesContent(12345, new List<string> { "A7" });
            BadgesContent badgeTwo = new BadgesContent(22345, new List<string> { "A1", "A4", "B1", "B2" });
            BadgesContent badgeThree = new BadgesContent(32345, new List<string> { "A4", "A5" });

            _repo.CreateNewBadge(badgeOne);
            _repo.CreateNewBadge(badgeTwo);
            _repo.CreateNewBadge(badgeThree);
        }
    }
}
