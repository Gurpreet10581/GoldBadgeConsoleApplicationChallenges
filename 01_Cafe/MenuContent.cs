using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuContent
    {
        public int MealNumber { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int Price { get; set; }

        public MenuContent() { }// empty constructer 

        public MenuContent(int mealNumber, string name, string description, string ingredients, int price)//overloaded constructer to create new objects for customer to use-blue ones are for customer use
        {
            MealNumber = mealNumber;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
