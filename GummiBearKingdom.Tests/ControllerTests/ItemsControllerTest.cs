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
    public class AnimalControllerTests
    {
        EFItemRepository db = new EFItemRepository(new TestDbContext());
        Mock<IItemRepository> mock = new Mock<IItemRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                 new Item {ItemId = 1, Description = "Pumpkin"},
                 new Item {ItemId = 2, Description = "Olive" },
                 new Item {ItemId = 3, Description = "Juice" }
            }.AsQueryable());
        }
        

    }
}
