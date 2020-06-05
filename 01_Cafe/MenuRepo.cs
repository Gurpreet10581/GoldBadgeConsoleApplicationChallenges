using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    
    public class MenuRepo
    {
        private readonly List<MenuContent> _MenuItems = new List<MenuContent>();// created a list to use the properties from MenuContent- which is saying that it can only take MenuContent object. Also, it is an empty list as of rigth now.List type is MenuContent

        //MenuContent item1 = new MenuContent(1,"Samosa","Indian","Aloo, Atta,Oil",5);// added item to MenuContent list to use below which will be saved with in field _MenutItems
        


        public bool AddItemToMenu(MenuContent content)
        {
            int startingCount = _MenuItems.Count;
            _MenuItems.Add(content);
            bool wasAdded = (_MenuItems.Count > startingCount) ? true : false;//bool because are method was bool and wasAdded is just a variable
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
