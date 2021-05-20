using _04_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Console
{
    class OutingUI
    {
        private OutingRepository _repo = new OutingRepository();
        public void Run()
        {
            bool menuRunning = true;
            while (menuRunning)
            {
                Console.Clear();
                Console.WriteLine("Company Outing Repoting and Adminstration Tool");
                Console.WriteLine("1. Display all outings\n" +
                    "2. Add an outing\n" +
                    "3. Display cost of all outings\n" +
                    "4. Display cost of outings by type\n" +
                    "5. Exit");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        DisplayAllOutings();
                        break;
                    case "2":
                    case "two":
                        AddNewOuting();
                        break;
                    case "3":
                    case "three":
                        DisplayTotalCost();
                        break;
                    case "4":
                    case "four":
                        DisplayCostByType();
                        break;
                    case "5":
                    case "five":
                        menuRunning = false;
                        break;
                }
            }
        }
        public void DisplayAllOutings()
        {
            List<OutingItem> currentOutings = new List<OutingItem>();
            currentOutings = _repo.GetAllOutings();
            Console.Clear();
            if (currentOutings.Count != 0)
            {
                Console.WriteLine("Current Outings:");
                foreach (OutingItem outing in currentOutings)
                {
                    Console.WriteLine($"Event Type:{outing.TypeOfEvent}\n" +
                        $"Date: {outing.DateOfEvent}\n" +
                        $"Number of People Attended: {outing.Attendance}\n" +
                        $"Cost of Event: ${outing.TotalCostOfEvent}\n" +
                        $"Cost per Attendee: ${Math.Round(outing.CostPerPerson, 2)}\n");
                }
                Console.WriteLine("Hit any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("There are no outings in database. Hit any key to continue.");
                Console.ReadKey();
            }

        }
        public void AddNewOuting()
        {
            OutingItem newOuting = new OutingItem();
            bool infoGood = false;
            Console.WriteLine("Please enter information below for new outing:");
            while (infoGood == false)
            {
                Console.WriteLine("Enter the type of outing (Golf, Bowling, Amusement Park, Concert)");
                string input = Console.ReadLine();

                if (input.ToLower() == "golf")
                { newOuting.TypeOfEvent = 0; }
                else if (input.ToLower() == "bowling")
                { newOuting.TypeOfEvent = (EventType)1; }
                else if (input.ToLower() == "amusement park")
                { newOuting.TypeOfEvent = (EventType)2; }
                else if (input.ToLower() == "concert")
                { newOuting.TypeOfEvent = (EventType)3; }
                else
                {
                    Console.WriteLine("Please enter a valid type. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                Console.WriteLine("Enter the date of the event (e.g. 04/11/2020):");
                newOuting.DateOfEvent = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the cost of event:");
                Console.Write("$");
                newOuting.TotalCostOfEvent = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter the number of people that attended:");
                newOuting.Attendance = Convert.ToInt32(Console.ReadLine());
                bool wasAdded = _repo.AddOuting(newOuting);
                if (wasAdded)
                {
                    Console.WriteLine("\n\nOuting was successfully added. Hit any key to conintue.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\n\nUnable to add outing. Hit any key to continue.");
                    Console.ReadKey();
                }
                infoGood = true;
            }
        }
        public void DisplayTotalCost()
        {
            decimal totalCost = _repo.GetTotalCost();
            Console.Clear();
            Console.WriteLine($"The total cost to date of outings is ${Math.Round(totalCost, 2)}");
            Console.WriteLine("Press any key to go back to menu.");
            Console.ReadKey();
        }
        public void DisplayCostByType()
        {
            decimal golfCost = 0;
            decimal bowlingCost = 0;
            decimal amusementParkCost = 0;
            decimal concertCost = 0;
            golfCost = _repo.GetCostByType(0);
            bowlingCost = _repo.GetCostByType(1);
            amusementParkCost = _repo.GetCostByType(2);
            concertCost = _repo.GetCostByType(3);
            Console.Clear();
            Console.WriteLine($"Total cost of Golf Outings: ${Math.Round(golfCost, 2)}");
            Console.WriteLine($"Total cost of Bowling Outings: ${Math.Round(bowlingCost, 2)}");
            Console.WriteLine($"Total cost of Amusement Park Outings: ${Math.Round(amusementParkCost, 2)}");
            Console.WriteLine($"Total cost of Concert Outings: ${Math.Round(concertCost, 2)}");
            Console.WriteLine("\nPress any key to go back to the menu.");
            Console.ReadKey();
        }
    }
}
