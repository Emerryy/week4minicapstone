using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        [TestMethod]
        public void Check_that_catering_object_is_created()
        {
            // Arrange 
            // Act
            Catering catering = new Catering();

            //Assert
            Assert.IsNotNull(catering);
        }
        [TestMethod]
        public void GetCateringItems_does_it_return_menu()
        {

            Catering catering = new Catering();
            CateringItem[] array = catering.GetCateringItems();
            string result = array[0].ToString();

            Assert.AreEqual("Item code B1, Soda, $1.50, 50 available", result);
        }
        [TestMethod]
        public void GetCateringItems_does_it_show_updated_inventory()
        {

            Catering catering = new Catering();
            catering.AccountBalance = 5000M;
            catering.Update("B1", 50);
            CateringItem[] array = catering.GetCateringItems();

            string result = array[0].ToString();

            Assert.AreEqual("Item code B1, Soda, $1.50, SOLD OUT", result);

        }


        [TestMethod]
        public void Update_does_it_purchase()
        {
            Catering catering = new Catering();
            CateringItem item = new CateringItem();
            catering.AccountBalance = 300M;
            item.Quantity = 50;

            string result = catering.Update("B1", 30);


            Assert.AreEqual("Purchase successful.", result);

        }
        [TestMethod]
        public void Update_does_it_check_quantity()
        {
            Catering catering = new Catering();

            catering.AccountBalance = 300M;

            string result = catering.Update("B1", 51);

            Assert.AreEqual("Sorry, but we don't have enough of that.", result);

        }
        [TestMethod]
        public void Update_does_it_check_money()
        {
            Catering catering = new Catering();

            catering.AccountBalance = 1M;

            string result = catering.Update("B1", 30);

            Assert.AreEqual("Sorry, you don't have enough money for that.", result);

        }

        

        [TestMethod]
        public void Update_does_it_check_item_codes()
        {
            Catering catering = new Catering();

            string result = catering.Update("H2", 20);

            Assert.AreEqual("Sorry, that product doesn't exist.", result);
        }
        [TestMethod]
        public void Update_does_it_say_soldout()
        {

            Catering catering = new Catering();
            catering.AccountBalance = 5000M;
            catering.Update("B1", 50);
            string result = catering.Update("B1", 15);
            

            

            Assert.AreEqual("Product sold out", result);

        }

        [TestMethod]
        public void Receipt_test()
        {

            Catering catering = new Catering();
            catering.AccountBalance = 5000M;
            catering.Update("B1", 10);
            string[] array = catering.Receipt();

            string result = array[0];

            Assert.AreEqual("10 Beverage Soda $1.50 $15.00", result);

        }

        [TestMethod]
        public void Receipt_test_multiple_items()
        {

            Catering catering = new Catering();
            catering.AccountBalance = 5000M;
            catering.Update("B1", 10);
            catering.Update("B1", 15);
            catering.Update("B1", 20);
            string[] array = catering.Receipt();

            string result = array[2];

            Assert.AreEqual("20 Beverage Soda $1.50 $30.00", result);

        }

        [TestMethod]
        public void TotalPurchase_test()
        {
            Catering catering = new Catering();
            catering.AccountBalance = 5000M;
            catering.Update("B1", 10);
            catering.Update("B1", 10);
            decimal result = catering.TotalPurchase();

            Assert.AreEqual(30.00M, result);

        }
        [TestMethod]
        public void TotalPurchase_test_if_zero_quantity()
        {
            Catering catering = new Catering();
            catering.AccountBalance = 5000M;
            catering.Update("D1", 0);
            catering.Update("A1", 0);
            decimal result = catering.TotalPurchase();

            Assert.AreEqual(0, result);

        }
        [TestMethod]
        public void TotalPurchase_test_if_no_purchase()
        {
            Catering catering = new Catering();
            catering.AccountBalance = 5000M;
            
            decimal result = catering.TotalPurchase();

            Assert.AreEqual(0, result);

        }

        [TestMethod]
        public void AddMoney_does_it_add()
        {
            Catering catering = new Catering();
            string result = catering.AddMoney(100.00M);
            Assert.AreEqual("Added successfully", result);
        }
        [TestMethod]
        public void AddMoney_does_it_add_cents()
        {
            Catering catering = new Catering();
            string result = catering.AddMoney(100.50M);
            Assert.AreEqual("Sorry, you can only add whole dollar amounts", result);
        }
        [TestMethod]
        public void AddMoney_does_it_add_to_existing_balance()
        {
            Catering catering = new Catering();
            catering.AccountBalance = 100.00m;
            string result = catering.AddMoney(100.00M);
            Assert.AreEqual("Added successfully", result);
        }
        [TestMethod]
        public void AddMoney_does_it_allow_more_than_5k()
        {
            Catering catering = new Catering();
            
            string result = catering.AddMoney(10000.00M);
            Assert.AreEqual("Sorry, your account balance can't exceed $5000", result);
        }
        [TestMethod]
        public void AddMoney_does_it_allow_5k()
        {
            Catering catering = new Catering();

            string result = catering.AddMoney(5000.00M);
            Assert.AreEqual("Added successfully", result);
        }
        [TestMethod]
        public void AddMoney_cant_pass_5K_w_balance()
        {
            Catering catering = new Catering();
            catering.AccountBalance = 250.00M;
            string result = catering.AddMoney(5000.00M);
            Assert.AreEqual("Sorry, your account balance can't exceed $5000", result);
        }

    }
}
