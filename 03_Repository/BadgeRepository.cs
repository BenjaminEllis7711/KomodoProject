using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Repository
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, List<string>> _badgeDirectory = new Dictionary<int, List<string>>();
        public bool AddBadge(int keyValue, List<string> doorsToAccess)
        {
            int startCount = _badgeDirectory.Count();
            _badgeDirectory.Add(keyValue, doorsToAccess);
            bool wasAdded = (_badgeDirectory.Count() > startCount) ? true : false;
            return wasAdded;
        }
        public List<string> GetDoorListByID(int badgeID)
        {
            List<string> currentDoors = new List<string>();
            bool foundDoors = _badgeDirectory.TryGetValue(badgeID, out currentDoors);
            if (foundDoors)
            {
                return currentDoors;
            }
            else return null;
        }
        public void RemoveDoor(int badgeID, string doorToRemove)
        {
            List<string> newDoors = new List<string>();
            newDoors = GetDoorListByID(badgeID);
            newDoors.Remove(doorToRemove);
            _badgeDirectory[badgeID] = newDoors;
        }
        public void AddDoor(int badgeID, string doorToAdd)
        {
            List<string> newDoors = new List<string>();
            newDoors = GetDoorListByID(badgeID);
            newDoors.Add(doorToAdd);
            _badgeDirectory[badgeID] = newDoors;
        }
        public Dictionary<int, List<string>> DisplayAllBadges()
        {
            return _badgeDirectory;
        }
        public void SeedBadgeList()
        {
            List<string> badgeOneDoors = new List<string>();
            badgeOneDoors.Add("A7");
            List<string> badgeTwoDoors = new List<string>();
            badgeTwoDoors.Add("A1");
            badgeTwoDoors.Add("A4");
            badgeTwoDoors.Add("B1");
            badgeTwoDoors.Add("B2");
            List<string> badgeThreeDoors = new List<string>();
            badgeThreeDoors.Add("A4");
            badgeThreeDoors.Add("A5");
            _badgeDirectory[12345] = badgeOneDoors;
            _badgeDirectory[22345] = badgeTwoDoors;
            _badgeDirectory[32345] = badgeThreeDoors;
        }
    }
}
