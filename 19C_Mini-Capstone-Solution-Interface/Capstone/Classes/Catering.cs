using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Interfaces;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        private List<CateringItem> inventory = new List<CateringItem>();
        private List<CateringItem> purchases = new List<CateringItem>();

        public IDataAccess fa = null;

        public decimal Balance { get; private set; } = 0M;

        public Catering(IDataAccess fa)
        {
            this.fa = fa;
            inventory = fa.GetInventory();
        }

        public void ClearPurchases()
        {
            purchases = new List<CateringItem>();
        }

        public CateringItem[] GetInventory()
        {
            return inventory.ToArray();
        }

        public CateringItem[] GetPurchases()
        {
            return purchases.ToArray();
        }

        public string MakeChange()
        {
            string result = "";

            Dictionary<string, int> currency = new Dictionary<string, int>();
            currency["Twenty"] = 2000;
            currency["Ten"] = 1000;
            currency["Five"] = 500;
            currency["One"] = 100;
            currency["Quarter"] = 25;
            currency["Dime"] = 10;
            currency["Nickle"] = 5;

            int cents = (int)(Balance * 100);

            foreach (KeyValuePair<string, int> item in currency)
            {
                if (cents / item.Value > 0)
                {
                    result += (cents / item.Value) + " - " + item.Key + ", ";
                    cents = cents % item.Value;
                }
            }

            //remove the last 2 characters (", ")
            if (result.Length > 2)
            {
                result = result.Substring(0, result.Length - 2);
            }

            fa.WriteLog("Return change", Balance, 0M);

            //set balance to zero
            Balance = 0M;

            return result;
        }

        public string AddMoney(string userInput)
        {
            string result = "";
            decimal inputAmount = 0M;

            try
            {
                inputAmount = decimal.Parse(userInput);
            }
            catch (FormatException ex)
            {
                result = ex.Message;
                return result;
            }

            if (inputAmount + Balance > 5000M)
            {
                result = "Amount too large. Balance limitd to $5000";
            }
            else if (inputAmount != Math.Ceiling(inputAmount) ||
                inputAmount != Math.Floor(inputAmount))
            {
                result = "Amount must be whole dollar amount.";
            }
            else
            {
                Balance += inputAmount;

                fa.WriteLog("Add money", inputAmount, Balance);
            }

            return result;
        }

        public bool IsProductValid(string product)
        {
            bool result = false;
            foreach (CateringItem item in inventory)
            {
                if (product == item.ProductCode)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public int Quanity(string quanity)
        {
            int result = 0;

            try
            {
                result = int.Parse(quanity);
            }
            catch
            {
                result = 0;
            }

            if (result < 0 || result > 50)
            {
                result = 0;
            }

            return result;
        }

        public bool IsSoldOut(string product)
        {
            bool result = false;
            foreach (CateringItem item in inventory)
            {
                if (product == item.ProductCode && item.Quanity == 0)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool IsSufficientQuanity(string product, string quanity)
        {
            bool result = false;

            int count = int.Parse(quanity);

            foreach (CateringItem item in inventory)
            {
                if (item.ProductCode == product && item.Quanity >= count)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool IsSufficientFunds(string product, string quanity)
        {
            bool result = false;

            int count = int.Parse(quanity);

            foreach (CateringItem item in inventory)
            {
                if ((item.ProductCode == product) && ((item.Price * count) <= Balance))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool MakePurchase(string product, string quanity)
        {
            bool result = false;
            int count = int.Parse(quanity);

            foreach (CateringItem item in inventory)
            {
                if (item.ProductCode == product)
                {

                    Balance -= item.Price * count;
                    item.Quanity -= count;

                    fa.WriteLog("Purchase " + item.ProductName, Balance + (item.Price * count), Balance);

                    CateringItem newItem = new CateringItem(item.ProductCode, item.ProductName,
                        item.Price, item.ProductType, count);
                    purchases.Add(newItem);

                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
