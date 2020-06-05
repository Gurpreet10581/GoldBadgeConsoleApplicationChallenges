using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI
{
    public class ProgramUI
    {
        MenuRepo _menuRepository = new MenuRepo();//creating a new instance with gives you access to everything in _menuRepository
        

        public void Run()
        {
            SeedMeals();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Cafe Menu Editor. Please select your options \n" +
                    "1. Add Items to Menu \n" +
                    "2. See The Menu\n" +
                    "3. Remove Item from Menu\n" +
                    "4. Exit ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddItemToMenu();
                        Console.WriteLine();
                        break;
                    case 2:
                        ListMenu();

                        Console.WriteLine("Press any key to continue...");

                        Console.ReadLine();
                       
                        break;
                        
                    case 3:
                        RemoveItemFromList();
                        
                        break;
                    case 4:
                        isRunning = false;
                        Console.WriteLine("Thank You and Come Agian");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Please select the right option");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void AddItemToMenu()
        {
            Console.Clear();
            MenuContent newContent = new MenuContent();
            Console.WriteLine("What number would you like to assign to this Meal?");
            newContent.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("\nWhat is the name for this Meal?");
            newContent.Name = Console.ReadLine();

            Console.WriteLine("\nAdvise the description of the Meal?");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("\nAdvise the ingredients for this Meal?");
            newContent.Ingredients = Console.ReadLine();

            Console.WriteLine("\nWhat will be the price for this Meal-Enter your $ Amount?");
            newContent.Price = int.Parse(Console.ReadLine());

            Console.WriteLine($"{newContent} will be added to the Menu. Press any key to continue...");
            _menuRepository.AddItemToMenu(newContent);
            Console.ReadLine();
            
        }
        public void ListMenu()
        {
            List<MenuContent> menuList = _menuRepository.GetMenu();
            foreach (MenuContent menuContent in menuList)
            {
                Console.WriteLine($"Meal# {menuContent.MealNumber}\n" +
                    $"Meal Name- {menuContent.Name}\n" +
                    $"Description-{menuContent.Description}\n" +
                    $"Ingredients- {menuContent.Ingredients}");
            }
        }
        public void RemoveItemFromList()
        {
            List<MenuContent> menuList = _menuRepository.GetMenu();
            int meal;

            Console.WriteLine("Enter the meal number that you would like to delete");

            bool isMeal = int.TryParse(Console.ReadLine(), out meal);
            if (isMeal)
            {
                foreach(MenuContent content in menuList.ToList())
                {
                    if (meal== content.MealNumber)
                    {
                        Console.WriteLine($"{content.MealNumber} will be removed from the Menu. Press any key to continue...");
                        _menuRepository.RemoveItemFromList(content);
                        Console.ReadLine();
                        
                    }
                }
            }
        }
      
        private void SeedMeals()
        {
            MenuContent mealOne = new MenuContent(1, "Pasta", "Italian", "Flour, Eggs, Salt, Water,Veggies", 12);
            MenuContent mealTwo = new MenuContent(2, "Hamburger", "American", "Meat, Eggs, Salt, Oil, Veggies", 9);
            MenuContent mealThree = new MenuContent(3, "Panini", "Italian", "Meat, Bread, Cheese,Sauce-Honey Mustered",7);
            MenuContent mealFour = new MenuContent(4, " Quesadilla", "Mexican", " Tortilla, Sour cream, pico de gallo, guacamole, oven-roasted jalapeño", 15);

            _menuRepository.AddItemToMenu(mealOne);
            _menuRepository.AddItemToMenu(mealTwo);
            _menuRepository.AddItemToMenu(mealThree);
            _menuRepository.AddItemToMenu(mealFour);
        }
    }
}
