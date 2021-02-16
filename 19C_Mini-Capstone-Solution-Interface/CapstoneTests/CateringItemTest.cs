using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CateringItemTest
    {
        [TestMethod]
        public void TestConstructor()

        {
            //arrange
            CateringItem cateringItem = new CateringItem("X1", "Test Product",
                1.00M, "X", 50);

            //act


            //assert
            Assert.AreEqual(cateringItem.ProductCode, "X1");

        }
    }
}
