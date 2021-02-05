using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        private List<CateringItem> items = new List<CateringItem>();
        FileAccess fileAccess = new FileAccess();

        private decimal totalPurchase = 0M;
        private List<string> receipt = new List<string>();

        private decimal balance = 0.00M;

        public decimal AccountBalance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }

        }

        public Catering()
        {
            //FileAccess fileAccess = new FileAccess();
            items = fileAccess.GetCateringItems();

        }

        public CateringItem[] GetCateringItems()
        {

            return items.ToArray();

        }

        public string Update(string productCode, int quantity)
        {

            foreach (CateringItem item in items)
            {
                if (item.Code == productCode)
                {
                    if (item.Quantity == 0)
                    {
                        return "Product sold out";
                    }
                    else if (quantity > item.Quantity)
                    {
                        return "Sorry, but we don't have enough of that.";
                    }
                    else if (balance < item.Price * quantity)
                    {
                        return "Sorry, you don't have enough money for that.";
                    }
                    else
                    {
                        item.Quantity -= quantity;
                        balance -= (item.Price * quantity);
                        receipt.Add($"{quantity} {item.Type} {item.Name} ${item.Price} ${item.Price * quantity}");
                        totalPurchase += (item.Price * quantity);
                        fileAccess.Audit($"{DateTime.Now} {quantity} {item.Name} ${item.Price * quantity} ${balance}");


                        return "Purchase successful.";

                    }

                }


            }
            return "Sorry, that product doesn't exist.";

        }


        public string[] Receipt()
        {
            string[] temp = receipt.ToArray();
            receipt.Clear();
            return temp;

        }
        public decimal TotalPurchase()
        {
            decimal temp = totalPurchase;
            totalPurchase = 0;


            return temp;
        }

        public string AddMoney(decimal addMoney)
        {
            if (addMoney % 1 != 0)
            {
                return "Sorry, you can only add whole dollar amounts";

            }
            else if (balance + addMoney > 5000.00M)
            {

                return "Sorry, your account balance can't exceed $5000";
            }
            else
            {
                balance += addMoney;
                fileAccess.Audit($"{DateTime.Now} ADD MONEY: ${addMoney} ${balance}");
                return "Added successfully";
            }
        }

    }
}

