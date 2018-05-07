using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;
using System.Collections.Generic;

namespace GummiBearKingdom.Tests
{
    [TestClass]
    public class ItemTests
    {
        public string Description { get; private set; }

        [TestMethod]
        public void GetDescription_ReturnsItem_String()
        {
            //Arrange
            var item = new ItemTests();
            item.Description = "Wash the Gummi";

            //Act 
            var result = item.Description;
            

            //Assert 
            Assert.AreEqual("Wash the Gummi", result);


        }
        [TestMethod]
        public void Constructor_ConstructNewItem_Item()
        {
            Item testItem = new Item { ItemId = 1, Name = "fuz", Description = "crazy", Cost = 12 };

            Assert.AreEqual(testItem.Name, "fuz");
        }

        [TestMethod]
        public void Setters_SetsProductInfo_Product()
        {
            //Arrange
            Item testItem = new Item { ItemId = 1, Name = "fuz", Description = "crazy", Cost = 12 };
            testItem.ItemId = 1;
            testItem.Name = "test name";
            testItem.Description = "test description";
            testItem.Cost = 2;

           //Act
            var descResult = testItem.Description;
            var nameResult = testItem.Name;
            var costResult = testItem.Cost;
            var idResult = testItem.ItemId;

            //Assert
            Assert.AreEqual("test description", descResult);
            Assert.AreEqual("test name", nameResult);
            Assert.AreEqual(2, costResult);
            Assert.AreEqual(1, idResult);


        }
        [TestMethod]
        public void Getters_GetsItemInfo_Item()
        {
            Item testProduct = new Item { ItemId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Cost = 2 };

            var idResult = testProduct.ItemId;
            var nameResult = testProduct.Name;
            var descResult = testProduct.Description;
            var priceResult = testProduct.Cost;
            

            Assert.AreEqual(idResult, 1);
            Assert.AreEqual(nameResult, "Gummi Bears");
            Assert.AreEqual(descResult, "Gummi Bears!");
            Assert.AreEqual(priceResult, 2);
          
        }

        [TestMethod]
        public void Get_AverageRating_Int()
        {
            Item testItem = new Item { ItemId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Cost = 3 };
            Review testReviewOne = new Review { ReviewId = 1, UserName = "A User", Body = "A Body", ItemId = 1, Rating = 0 };
            Review testReviewTwo = new Review { ReviewId = 2, UserName = "A User", Body = "A Body", ItemId = 1, Rating = 0 };
            testItem.Reviews = new List<Review> { testReviewOne, testReviewTwo };

            double avgRating = testItem.AvgRating();

            Assert.AreEqual(avgRating, 0);
        }


    }
}
