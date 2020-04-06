using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    
    public class MenuRepo
    {
        List<MenuContent> _MenuItems = new List<MenuContent>();//creating a feild

        
        //making methods below

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

        public bool UpdateExistingContent(string orginalName, MenuContent updatedContent)
        {
            MenuContent oldContent = GetMenuByName(orginalName);
            if(oldContent != null)
            {
                oldContent.MealNumber = updatedContent.MealNumber;
                oldContent.Name = updatedContent.Name;
                oldContent.Description = updatedContent.Description;
                oldContent.Ingredients = updatedContent.Ingredients;
                oldContent.Price = updatedContent.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveItemFromList(MenuContent menuContent)
        {
            bool RemoveItem = _MenuItems.Remove(menuContent);
            return RemoveItem;
        }


    }
}
