using _03_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Console
{
    class BadgesUI
    {
        private BadgeRepository _repo = new BadgeRepository();
        public void Run()
        {
            _repo.SeedBadgeList();
            bool menuRunning = true;
            while (menuRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin. What would you like to do?");
                Console.WriteLine("1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit\n");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        AddNewBadge();
                        break;
                    case "2":
                    case "two":
                        UpdateBadge();
                        break;
                    case "3":
                    case "three":
                        DisplayAllBadges();
                        break;
                    case "4":
                    case "four":
                        menuRunning = false;
                        break;
                }
            }
        }
        public void DisplayAllBadges()
        {
            Dictionary<int, List<string>> currentBadges = new Dictionary<int, List<string>>();
            currentBadges = _repo.DisplayAllBadges();
            Console.Clear();
            Console.WriteLine("Key");
            Console.WriteLine("Badge #\t\t" + "Door Access");
            foreach (KeyValuePair<int, List<string>> badge in currentBadges)
            {
                Console.Write(badge.Key + " \t\t");
                Console.Write(string.Join(", ", badge.Value));
                Console.WriteLine("");
            }
            Console.WriteLine("Hit any key to return to the menu.");
            Console.ReadLine();
        }
        public void AddNewBadge()
        {
            bool addingMoreDoors = true;
            BadgeItem newBadge = new BadgeItem();
            newBadge.AccessToDoors = new List<string>();
            Console.Clear();
            Console.Write("What is the number of the badge: ");
            newBadge.BadgeID = Convert.ToInt32(Console.ReadLine());
            while (addingMoreDoors)
            {
                Console.Write("\n\n List a door that it needs access to: ");
                newBadge.AccessToDoors.Add(Console.ReadLine());
                Console.Write("\nAny other doors? (y/n)");
                string moreDoors = Console.ReadLine();
                if (moreDoors.ToLower() == "n")
                {
                    addingMoreDoors = false;
                }
            }
            bool badgeAdded = _repo.AddBadge(newBadge.BadgeID, newBadge.AccessToDoors);
            if (badgeAdded)
            {
                Console.WriteLine("\n\n Successfully added badge. Please hit any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\n\n Unable to add badge. Please hit any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }

        }
        public void UpdateBadge()
        {
            BadgeItem updateBadge = new BadgeItem();
            updateBadge.AccessToDoors = new List<string>();
            string doorHolder;
            Console.Write("\n\nWhat is the badge number to update:");
            updateBadge.BadgeID = Convert.ToInt32(Console.ReadLine());
            updateBadge.AccessToDoors = _repo.GetDoorListByID(updateBadge.BadgeID);
            Console.WriteLine($"\n\nBadge #{updateBadge.BadgeID} has access to doors {string.Join(" & ", updateBadge.AccessToDoors)},");
            Console.WriteLine("\nWhat would you like to do?" +
                "\n1. Remove a door" +
                "\n2. Add a door");
            int inputChoice = Convert.ToInt32(Console.ReadLine());
            if(inputChoice == 1)
            {
                Console.Write("\nWhich door would you like to remove? ");
                doorHolder = Console.ReadLine();
                _repo.RemoveDoor(updateBadge.BadgeID, doorHolder);
                updateBadge.AccessToDoors = _repo.GetDoorListByID(updateBadge.BadgeID);
                if (updateBadge.AccessToDoors.Count == 0)
                {
                    Console.WriteLine("\nDoor has been removed.");
                    Console.WriteLine($"Badge #{updateBadge.BadgeID} now has access to no doors.");
                }
                else
                {
                    Console.WriteLine("\nDoor has been removed.");
                    Console.WriteLine($"Badge #{updateBadge.BadgeID} now has access to doors {string.Join(" & ", updateBadge.AccessToDoors)}.");
                }
            }
            else if (inputChoice == 2)
            {
                Console.Write("\nWhich door would you like to add? ");
                doorHolder = Console.ReadLine();
                _repo.AddDoor(updateBadge.BadgeID, doorHolder);
                updateBadge.AccessToDoors = _repo.GetDoorListByID(updateBadge.BadgeID);
                Console.WriteLine("\nDoor has been added.");
                Console.WriteLine($"Badge #{updateBadge.BadgeID} now has access to doors {string.Join(" & ", updateBadge.AccessToDoors)}.");
            }
            else Console.WriteLine("Please enter a valid choice");
            Console.ReadKey();
        }
    }
}
