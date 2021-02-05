using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTest
    {
        [TestMethod]
        public void Change_does_it_give()
        {
            Catering catering = new Catering();
            Change change = new Change();
            catering.AccountBalance = 100M;
            string result = change.GiveChange(catering);
            Assert.AreEqual($"You were given 5 20's, 0 10's, 0 5's, 0 1's, 0 quarters, 0 dimes, and 0 nickels. Thanks!", result);
        }
        [TestMethod]
        public void Change_does_it_give_small_bills()
        {
            Catering catering = new Catering();
            Change change = new Change();
            catering.AccountBalance = 116M;
            string result = change.GiveChange(catering);
            Assert.AreEqual($"You were given 5 20's, 1 10's, 1 5's, 1 1's, 0 quarters, 0 dimes, and 0 nickels. Thanks!", result);
        }
        [TestMethod]
        public void Change_does_it_give_coins()
        {
            Catering catering = new Catering();
            Change change = new Change();
            catering.AccountBalance = .40M;
            string result = change.GiveChange(catering);
            Assert.AreEqual($"You were given 0 20's, 0 10's, 0 5's, 0 1's, 1 quarters, 1 dimes, and 1 nickels. Thanks!", result);
        }
        [TestMethod]
        public void Change_does_it_give_bills_and_coins()
        {
            Catering catering = new Catering();
            Change change = new Change();
            catering.AccountBalance = 36.40M;
            string result = change.GiveChange(catering);
            Assert.AreEqual($"You were given 1 20's, 1 10's, 1 5's, 1 1's, 1 quarters, 1 dimes, and 1 nickels. Thanks!", result);
        }
        [TestMethod]
        public void Change_if_no_balance()
        {
            Catering catering = new Catering();
            Change change = new Change();
            catering.AccountBalance = 0M;
            string result = change.GiveChange(catering);
            Assert.AreEqual($"You were given 0 20's, 0 10's, 0 5's, 0 1's, 0 quarters, 0 dimes, and 0 nickels. Thanks!", result);
        }
    }
}
