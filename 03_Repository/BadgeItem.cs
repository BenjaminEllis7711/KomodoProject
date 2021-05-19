using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Repository
{
    public class BadgeItem
    {
        public int BadgeID { get; set; }
        public List<string> AccessToDoors { get; set; }
        public BadgeItem() { }
        public BadgeItem(int badgeID, List<string> accessToDoors)
        {
            BadgeID = badgeID;
            AccessToDoors = accessToDoors;
        }
    }
}
