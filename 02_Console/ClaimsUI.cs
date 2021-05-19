﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_Repository;

namespace _02_Console
{
    class ClaimsUI
    {
        private ClaimRepository _repo = new ClaimRepository();
        public void Run()
        {
            _repo.SeedClaimDirectory();
            bool menuRunning = true;
            while (menuRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Claims Department");
                Console.WriteLine("Choose a menu item:\n");
                Console.WriteLine("1. See all claims\n\n" +
                    "2. Take care of next claim\n\n" +
                    "3. Enter a new claim\n\n" +
                    "4. Exit\n");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        DisplayAllClaims();
                        break;
                    case "2":
                    case "two":
                        HandleNextClaim();
                        break;
                    case "3":
                    case "three":
                        
                        break;
                    case "4":
                    case "four":
                        menuRunning = false;
                        break;

                }
            }
        }
        public void DisplayAllClaims()
        {
            Queue<ClaimItem> allClaims = new Queue<ClaimItem>();
            allClaims = _repo.DisplayClaims();
            string header = "";
            string content;
            header += String.Format("{0, 9}", "ClaimID");
            header += String.Format("{0, 10}", "Type");
            header += String.Format("{0, 30}", "Description");
            header += String.Format("{0, 15}", "Amount");
            header += String.Format("{0, 25}", "Date Of Accident");
            header += String.Format("{0, 25}", "Date Of Claim");
            header += String.Format("{0, 15}", "Is Valid?");
            Console.WriteLine(header);
            foreach(ClaimItem claimItem in allClaims)
            {
                content = "";
                content += String.Format("{0, 9}", claimItem.ClaimId);
                content += String.Format("{0, 10}", claimItem.Type);
                content += String.Format("{0, 30}", claimItem.Description);
                content += String.Format("{0, 15}", claimItem.Amount);
                content += String.Format("{0, 25}", claimItem.DateOfAccident);
                content += String.Format("{0, 25}", claimItem.DateOfClaim);
                content += String.Format("{0, 15}", claimItem.IsValid);
                Console.WriteLine(content);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        public void HandleNextClaim()
        {
            ClaimItem nextClaim = new ClaimItem();
            nextClaim = _repo.DisplayNextClaim();
            bool wasHandled = false;
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine($"ClaimID: {nextClaim.ClaimId}\n\n" +
                $"Type: {nextClaim.Type}\n\n" +
                $"Description: {nextClaim.Description}\n\n" +
                $"Amount: ${nextClaim.Amount}\n\n" +
                $"Date of Accident: {nextClaim.DateOfAccident}\n\n" +
                $"Date of Claim: {nextClaim.DateOfClaim}\n\n" +
                $"Is Valid? {nextClaim.IsValid}\n\n\n");
            Console.WriteLine("Do you want to deal with the claim now (y/n)?");
            string input = Convert.ToString(Console.ReadKey());
            Console.WriteLine("\n");
            if(input.ToLower() == "y")
            {
                wasHandled = _repo.HandleNextItem();
            }
            if(wasHandled)
            {
                Console.WriteLine("You have successfully handled claim. Press any key to continue.");
            }
            else
            {
                Console.WriteLine("Unable to handle claim. Please try again. Press any key to continue.");
            }
            Console.ReadLine();

        }
    }
}
