using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Repository
{
    public class ClaimRepository
    {
        private readonly Queue<ClaimItem> _claimDirectory = new Queue<ClaimItem>();

        public Queue<ClaimItem> DisplayClaims()
        {
            return _claimDirectory;
        }
        
        public bool AddClaimToDirectory(ClaimItem newClaim)
        {
            int claimCount = _claimDirectory.Count();
            _claimDirectory.Enqueue(newClaim);
            bool wasClaimAdded = (_claimDirectory.Count() > claimCount) ? true : false;
            return wasClaimAdded;
        }

        public ClaimItem DisplayNextClaim()
        {
            return _claimDirectory.Peek();
        }

        public bool HandleNextItem()
        {
            int startCount = _claimDirectory.Count();
            ClaimItem trash = new ClaimItem();
            trash = _claimDirectory.Dequeue();
            if (startCount < _claimDirectory.Count())
            {
                return true;
            }
            else return false;
        }

        public void SeedClaimDirectory()
        {
            ClaimItem claimOne = new ClaimItem(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            ClaimItem claimTwo = new ClaimItem(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            ClaimItem claimThree = new ClaimItem(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));
            _claimDirectory.Enqueue(claimOne);
            _claimDirectory.Enqueue(claimTwo);
            _claimDirectory.Enqueue(claimThree);
        }
    }
}
