using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    
    public class MenuRepo
    {
        private readonly List<MenuContent> _MenuItems = new List<MenuContent>();


        public bool AddItemToMenu(MenuContent content)
        {
            int startingCount = _MenuItems.Count;
            _MenuItems.Add(content);
            bool wasAdded = (_MenuItems.Count > startingCount) ? true : false;
            return wasAdded;
        }

      
        public List<MenuContent> GetMenu()
        {
            return _MenuItems;
        }

        public MenuContent GetMenuByName(string name)
        {
            foreach (MenuContent content in _MenuItems)
            {
                if (content.Name.ToLower() == name.ToLower())
                {
                    return content;
                }
            }
            return null;
        }


        public bool RemoveItemFromList(MenuContent menuContent)
        {
            bool RemoveItem = _MenuItems.Remove(menuContent);
            return RemoveItem;
        }


    }
}
