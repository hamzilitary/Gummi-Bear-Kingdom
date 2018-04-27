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

      
       
    }
}
