using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System;
using Capstone.Interfaces;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        IDataAccess fa = new FileAccess();

        [TestInitialize]
        public void TestInitilize()
            {
            }

        [TestMethod]
        public void TestConstructor()
        {
            //arrange
            Catering catering = new Catering(fa);

            //act
            CateringItem[] items = catering.GetInventory();

            //assert
            Assert.IsTrue(items.Length > 0);
        }

        [TestMethod]
        public void TestClearPurchases()
        {
            //arrange
            Catering catering = new Catering(fa);
            CateringItem[] items = catering.GetInventory();
            string code = items[0].ProductCode; //first item

            catering.AddMoney("20");
            catering.MakePurchase(code, "1");

            //act
            CateringItem[] purchases = catering.GetPurchases();

            //assert
            Assert.AreEqual(1, purchases.Length);

            //act
            catering.ClearPurchases();
            purchases = catering.GetPurchases();

            //assert
            Assert.AreEqual(0, purchases.Length);

        }

        [TestMethod]
        public void TestGetInventory()
        {
            //arrange
            Catering catering = new Catering(fa);

            //act
            CateringItem[] items = catering.GetInventory();

            //assert
            Assert.IsTrue(items.Length > 0);
        }

        [TestMethod]
        public void TestGetPurchases()
        {
            //arrange
            Catering catering = new Catering(fa);
            CateringItem[] items = catering.GetInventory();
            string code = items[0].ProductCode; //first item

            catering.AddMoney("20");
            catering.MakePurchase(code, "1");

            //act
            CateringItem[] purchases = catering.GetPurchases();

            //assert
            Assert.AreEqual(1, purchases.Length);
        }

        [TestMethod]
        public void TestMakeChange()
        {
            //arrange
            Catering catering = new Catering(fa);

            //act
            catering.AddMoney("20");

            //Assert
            Assert.AreEqual("1 - Twenty", catering.MakeChange());

            //act
            catering.AddMoney("40");

            //Assert
            Assert.AreEqual("2 - Twenty", catering.MakeChange());

            //act
            catering.AddMoney("50");

            //Assert
            Assert.AreEqual("2 - Twenty, 1 - Ten", catering.MakeChange());


        }

        [TestMethod]
        public void TestAddMoney()
        {
            //arrange
            Catering catering = new Catering(fa);

            //act
            catering.AddMoney("20");

            //assert
            Assert.AreEqual(20.00M, catering.Balance);
        }

        [TestMethod]
        public void TestIsProductValid()
        {
            //arrange
            Catering catering = new Catering(fa);
            CateringItem[] items = catering.GetInventory();
            string code = items[0].ProductCode; //first item

            //assert
            Assert.IsTrue(catering.IsProductValid(code));

            //assert - assume Z1 is not a vaild code
            Assert.IsFalse(catering.IsProductValid("Z1"));
        }

        [TestMethod]
        public void TestQuanity()
        {
            //arrange
            Catering catering = new Catering(fa);

            //act
            int result = catering.Quanity("7");

            //assert
            Assert.AreEqual(7, result);

            //act
            result = catering.Quanity("seven");

            //assert
            Assert.AreEqual(0, result);

        }

        [TestMethod]
        public void TestIsSoldOut()
        {
            //arrange
            Catering catering = new Catering(fa);
            CateringItem[] items = catering.GetInventory();
            string code = items[0].ProductCode; //first item
            catering.AddMoney("2000");

            //act
            catering.MakePurchase(code, "50");

            //assert
            Assert.IsTrue(catering.IsSoldOut(code));
        }

        [TestMethod]
        public void TestIsSufficientQuanity()
        {
            //arrange
            Catering catering = new Catering(fa);
            CateringItem[] items = catering.GetInventory();
            string code = items[0].ProductCode; //first item

            // act
            catering.AddMoney("2000");

            //assert
            Assert.IsTrue(catering.IsSufficientQuanity(code, "50"));
        }

        [TestMethod]
        public void TestsSufficientFunds()
        {
            //arrange
            Catering catering = new Catering(fa);
            CateringItem[] items = catering.GetInventory();
            string code = items[0].ProductCode; //first item
            decimal price = items[0].Price;

            //act
            //how much for 5 of them?
            decimal extendedPrice = price * 5;

            //add that amount + 1 dollar
            int moneyToAdd = (int)Math.Ceiling(extendedPrice) + 1;
            catering.AddMoney(moneyToAdd.ToString());


            Assert.IsTrue(catering.IsSufficientFunds(code, "5"));
            Assert.IsFalse(catering.IsSufficientFunds(code, "10"));
        }

        [TestMethod]
        public void TestMakePurchase()
        {
            //arrange
            Catering catering = new Catering(fa);
            CateringItem[] items = catering.GetInventory();
            string code = items[0].ProductCode; //first item

            catering.AddMoney("20");
            catering.MakePurchase(code, "1");

            //act
            CateringItem[] purchases = catering.GetPurchases();

            //assert
            Assert.AreEqual(1, purchases.Length);
        }
    }
}
