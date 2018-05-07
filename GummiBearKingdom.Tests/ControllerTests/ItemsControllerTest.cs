using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;
using GummiBearKingdom.Controllers;
using Moq;
using System.Linq;

namespace GummiBearKingdom.Tests.ControllerTests
{

    [TestClass]
    public class ItemsControllerTests
    {
        Mock<IItemRepository> mock = new Mock<IItemRepository>();
        EFItemRepository db = new EFItemRepository(new TestDbContext());

        private void DbSetup()
        {
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item {ItemId = 1, Description = "Wash the dog" },
                new Item {ItemId = 2, Description = "Do the dishes" },
                new Item {ItemId = 3, Description = "Sweep the floor" }
            }.AsQueryable());
        }


        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of items
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Item>));
        }

        [TestMethod]
        public void ItemsController_IndexModelContainCorrectData_List()
        {
            //Arrange
            ItemsController controller = new ItemsController();
            IActionResult actionResult = controller.Index();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Item>));

        }

        [TestMethod]
        public void Mock_IndexModelContainsItems_Collection()
        {
            //Arrange 
            DbSetup();

            Item testItem = new Item();
            testItem.ItemId = 1;
            testItem.Name = "pumpkin gummi bear";
            testItem.Cost = 5;
            testItem.Description = "the most wonderful pumpkin in all the pumpkin patch";
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //Act 
            var resultView = (ViewResult)controller.Create();

            //Assert 
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));


        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {

            //Arrange
            Item item = new Item();
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);


            //Act 
            var resultView = controller.Details(item.ItemId) as ViewResult;
            var model = resultView.ViewData.Model as Item;

            //Assert 
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));

        }

        [TestMethod]
        public void Mock_PostResultViewEdit_Viewresult()
        {
            //Arrange
            Item testItem = new Item();
            testItem.ItemId = 2;
            testItem.Name = "gorilla glue";
            testItem.Cost = 3;
            testItem.Description = "dankest gummi bear";
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //Act
            var resultView = controller.Edit(testItem.ItemId) as ViewResult;

            //Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
        }
      
           

            
    }



      
       
}

