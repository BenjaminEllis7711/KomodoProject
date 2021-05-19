using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Repository
{
    public enum ClaimType { Car, Home, Theft }
    public class ClaimItem
    {
        public int ClaimId { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan timeBetween = new TimeSpan();
                timeBetween = DateOfClaim - DateOfAccident;
                int intTimeBetween = Convert.ToInt32(timeBetween.TotalDays);
                if (intTimeBetween < 30)
                {
                    return true;
                }
                else return false;
            }
        }
        public ClaimItem() { }
        public ClaimItem(int claimID, ClaimType type, string description, decimal amount, DateTime dateOfAccident, DateTime dateOfClaim)
        {
            ClaimId = claimID;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
        }

    }
}
