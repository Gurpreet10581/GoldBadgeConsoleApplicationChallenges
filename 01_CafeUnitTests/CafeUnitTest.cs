using System;
using System.Collections.Generic;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeUnitTests
{
    [TestClass]
    public class CafeUnitTest
    {
        
        MenuRepo _repo = new MenuRepo();// creaatinglist to link with repository first step to access


        [TestMethod]
        public void AddName_ShouldAddName()
        {
            MenuContent content = new MenuContent();

            content.Name = "Pasta";
            string expected = "Pasta";
            string actual = content.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddItemToMenu_ShouldGeCorrectBool()
        {
            MenuContent content = new MenuContent();
            MenuRepo repo = new MenuRepo();

            bool addItem = repo.AddItemToMenu(content);

            Assert.IsTrue(addItem);

        }

        public void GetMenu_ShouldReturnCorrectMenu()
        {
            MenuContent testContent = new MenuContent();
            MenuRepo repo = new MenuRepo();
            repo.AddItemToMenu(testContent);

            List<MenuContent> testList = repo.GetMenu();
            bool menuHasContent = testList.Contains(testContent);
        }



        [TestMethod]
        public void GetByName_ShouldReturnCorrectName()
        {
            //Arrange


            MenuContent content = new MenuContent(1, "Pasta", "Italian", "Flour, Eggs, Salt, Water", 5);
            List<MenuContent> menuItems = _repo.GetMenu();
            menuItems.Add(content);

            

            //Act

            MenuContent actual = _repo.GetMenuByName("Pasta");
            MenuContent expected = content;
            //Assert
            Assert.AreEqual(expected,actual);
        }

        public void UpdateExistingMenu_ShouldReturnTrue()
        {

            MenuContent newContent = new MenuContent(1, "Pasta", "Italian", "Flour, Eggs, Salt, Water", 5);
            bool updateResult = _repo.UpdateExistingContent("Pasta", newContent);
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            //Arrange
            MenuContent newContent = new MenuContent(2, "Hamburger", "American", "Flour, Eggs, Salt, Water", 9);
            List<MenuContent> newList = _repo.GetMenu();
            newList.Add(newContent);

            //Act

            _repo.RemoveItemFromList(newContent);
            bool isRemoved = newList.Contains(newContent);
            
            //Act

            Assert.IsFalse(isRemoved);
        }
    }
}

