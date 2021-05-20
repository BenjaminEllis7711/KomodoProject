using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Repository
{
    public class OutingRepository
    {
        private readonly List<OutingItem> _outingRepository = new List<OutingItem>();
        public List<OutingItem> GetAllOutings()
        {
            return _outingRepository;
        }
        public bool AddOuting(OutingItem newOuting)
        {
            int startingCount = _outingRepository.Count;
            _outingRepository.Add(newOuting);
            if (startingCount < _outingRepository.Count)
            {
                return true;
            }
            else return false;
        }
        public decimal GetTotalCost()
        {
            decimal totalCost = 0;
            foreach(OutingItem outing in _outingRepository)
            {
                totalCost += outing.TotalCostOfEvent;
            }
            return totalCost;
        }
        public decimal GetCostByType(int outingType)
        {
            decimal costForType = 0;
            foreach(OutingItem outing in _outingRepository)
            {
                if(outing.TypeOfEvent == (EventType)outingType)
                {
                    costForType += outing.TotalCostOfEvent;
                }
            }
            return costForType;
        }

    }
}
