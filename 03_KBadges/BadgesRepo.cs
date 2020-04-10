using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KBadges
{
    public class BadgesRepo
    {

        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();



        public Dictionary<int, List<string>> ListOfBadgesAndDoors()
        {
            return _badgeDictionary;
        }
        public bool CreateNewBadge(BadgesContent newbadge)
        {
            _badgeDictionary.Add(newbadge.BadgeId, newbadge.DoorAccess);

            if (_badgeDictionary.ContainsKey(newbadge.BadgeId))
            {
                return true;
            }
            return false;
        }

        public List<string> GetDoorsByBadgeId(int badgeId)
        {
            foreach (KeyValuePair<int, List<string>> content in _badgeDictionary)
            {
                if (content.Key == badgeId)
                {
                    return content.Value;
                }
            }
            return null;
        }

        public bool RemoveDoorsFromBadge(int badges, string door)
        {
            List<string> doors = GetDoorsByBadgeId(badges);
            doors.Remove(door);//used doors and called remove method and put door in to specify 

            if (doors.Contains(door))
            {
                return false;
            }
            return true;
        }
        //to add multiple doors
        // pass in a List<string> doorsToAdd instead of a single string, so that means we'll have to new up a List and populate it with the doors we want to add
        // getdoorsbybadgeId to get our Value from our KeyValuePair
        // foreach through that list
        // add each door to that list
        
        public bool AddDoorsToBadge(int badges, string door)
        {
            List<string> doors = GetDoorsByBadgeId(badges);
            doors.Add(door);

            if (doors.Contains(door))
            {
                return true;
            }
            return false;

        }

        public void seed()
        {
            List<string> seedList = new List<string>() { "A7", "A8", "A9", "A5" };
            List<string> seedListOne = new List<string>() { "A73", "A84", "A59", "A59" };
            BadgesContent badgeOne = new BadgesContent(1, seedList);
            BadgesContent badgeTwo = new BadgesContent(2, seedListOne);
            _badgeDictionary.Add(badgeOne.BadgeId, badgeOne.DoorAccess);//adding keyvaluepair to dict
            _badgeDictionary.Add(badgeTwo.BadgeId, badgeTwo.DoorAccess);

        }

    }
}
