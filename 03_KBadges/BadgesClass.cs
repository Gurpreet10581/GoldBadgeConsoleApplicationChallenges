using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KBadges
{
    public class BadgesClass
    {
        public int BadgeId { get; set; }
        public List<string> DoorAccess { get; set; }

        public BadgesClass() { }

        public BadgesClass(int badgeID, List<string> doorAccess)
        {
            BadgeId = badgeID;
            DoorAccess = doorAccess;

        }

    }
}
