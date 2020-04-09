using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KBadges
{
    public class BadgesContent
    {
        public int BadgeId { get; set; }
        public List<string> DoorAccess { get; set; }

        public BadgesContent() { }

        public BadgesContent(int badgeId, List<string> doorAccess)
        {
            BadgeId = badgeId;
            DoorAccess = doorAccess;

        }

    }
}
