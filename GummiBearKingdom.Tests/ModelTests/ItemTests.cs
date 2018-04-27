using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;

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

        
        
    }
}
