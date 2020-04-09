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
        List<string> doors = new List<string>();
        List<int> Convert(List<string> stringList)
        {
            List<int> intList = new List<int>();

            for (int i = 0; i < stringList.Count; i++)
            {
                intList.Add(int.Parse(stringList[i]));
            }
            return intList;
        }

        public Dictionary<int, List<string>> ListOfBadgesAndDoors(BadgesContent listItems)
        {
            return _badgeDictionary;
        }
        public void CreateNewBadge(BadgesContent newbadge)
        {
            _badgeDictionary.Add(newbadge.BadgeId, newbadge.DoorAccess);
            
        }

        public BadgesContent GetContentByBadgeId(int badgeId)
        {
            foreach (KeyValuePair<int, List<string>> content in _badgeDictionary)
            {
                foreach (string door in content.Value)
                {
                    if (content.Key == badgeId)
                    {
                        BadgesContent badge = new BadgesContent(content.Key, content.Value);
                        return badge;
                    }
                }

            }
            return null;
        }

        public void RemoveDoorsFromBadge(int badges)
        {
            _badgeDictionary.Remove(badges);

        }
        public BadgesContent UpdateDoorForBadge(int originalbadgeId, BadgesContent updateContent)
        {

            BadgesContent oldContent = GetContentByBadgeId(originalbadgeId);
            if (oldContent != null)
            {
                oldContent.BadgeId = updateContent.BadgeId;
                oldContent.BadgeId = updateContent.DoorAccess;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
