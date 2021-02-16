using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class FileAccessTest
    {
        [TestMethod]
        public void TestGetInventory()

        {
            //arrange
            FileAccess fa = new FileAccess();

            //act
            List<CateringItem> items = fa.GetInventory();

            //assert
            Assert.IsTrue(items.Count > 0);

        }

        [TestMethod]
        public void TestWriteLog()
        {
            //arrange
            FileAccess fa = new FileAccess();

            //act
            bool result = fa.WriteLog("Test", 999.99M, 999.99M);

            //assert
            Assert.IsTrue(result);
        }

    }
}
