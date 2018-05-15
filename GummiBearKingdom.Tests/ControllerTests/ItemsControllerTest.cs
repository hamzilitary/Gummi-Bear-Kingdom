using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;
using GummiBearKingdom.Controllers;
using Moq;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GummiBearKingdom.Tests.ControllerTests
{

    [TestClass]
    public class ItemsControllerTests : IDisposable
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddEntityFrameworkMySql()
                .AddDbContext<GummiBearKingdomDbContext>(options =>
                options
                .UseMySql(Configuration["ConnectionStrings:TestConnection"]));
        }
        public IConfiguration Configuration { get; set; }
        Mock<IItemRepository> mock = new Mock<IItemRepository>();
        

        public virtual void Dispose()
        {
            GummiBearKingdomDbContext context = new GummiBearKingdomDbContext();
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE items");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE reviews");
            
        }

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

        [TestMethod]
        public void Mock_PostResultViewDelete_ViewResult()
        {
            //Arrange 
            Item testItem = new Item();
            testItem.ItemId = 2;
            testItem.Name = "Girl Scout Cookies";
            testItem.Cost = 5;
            testItem.Description = "dank gummi";

            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //Act
            var resultView = controller.Delete(testItem.ItemId) as ViewResult;

            //Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));


        }

        EFItemRepository db = new EFItemRepository(new TestDbContext());
        [TestMethod]
        public void DB_CreateNewEntries_Collection()
        {
            //Arrange 
            ItemsController controller = new ItemsController(db);
            Item testItem = new Item
            {
                ItemId = 66,
                Name = "Bruce Banner",
                Cost = 4,
                Description = "hulk"
            };

            //Act
            controller.Create(testItem);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Item>;

            //Assert
            CollectionAssert.Contains(collection, testItem);

            
        }
        
        [TestMethod]
        public void testDb_Delete_RemovesToDb()
        {
            //Arrange
            ItemsController controller = new ItemsController(db);
            Item testItem = new Item
            {
                ItemId = 5,
                Name = "Sarah Pearson gummi flavor",
                Description = "pumpkin suprise",
                Cost = 100000,

            };
            //Act
            controller.Create(testItem);
            controller.DeleteConfirmed(testItem.ItemId);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Item>;

            //Assert
            CollectionAssert.DoesNotContain(collection, testItem);
        

        }

        [TestMethod]
        public void test_Db_Edit_UpdatesInDb()
        {
            //Arrrange
            ItemsController controller = new ItemsController(db);
            Item testItem = new Item
            {
                ItemId = 16,
                Name = "Lil Pump",
                Description = "rap gummi",
                Cost = 234


            };
            Item updatedItem = new Item
            {
                ItemId = 9,
                Name = "Lil Flip",
                Description = "rap dummi",
                Cost = 123


            };

            //Act
            controller.Create(testItem);
            testItem.Name = "Lil Flip";
            controller.Edit(testItem);
            var returnItem = (controller.Details(1) as ViewResult).ViewData.Model as Item;

            //Assert
            Assert.AreEqual(returnItem.Name, "Lil Flip");

        }

        
      
           

            
    }



      
       
}

