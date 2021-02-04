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
        CateringItem cateringItem = new CateringItem();


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
            FileAccess fileAccess = new FileAccess();
            items = fileAccess.GetCateringItems();

        }

        public CateringItem[] GetCateringItems()
        {

            foreach (CateringItem item in items)
            {
                if (item.Quantity == 0)
                {
                    item.Name = item.Name + "***SOLDOUT***";


                }
            }
            return items.ToArray();

        }
        public void Update(string productCode, int quantity)
        {

            foreach (CateringItem item in items)
            {
                if (item.Code == productCode)
                {
                    if (item.Quantity == 0)
                    {
                        Console.WriteLine("Product sold out");
                    }
                    else if (quantity > item.Quantity)
                    {
                        Console.WriteLine("Sorry, but we don't have enough of that.");
                    }
                    else if (balance < item.Price * quantity)
                    {
                        Console.WriteLine("Sorry, you don't have enough money for that.");
                    }
                    else
                    {
                        item.Quantity -= quantity;
                        balance -= (item.Price * quantity);

                    }

                }


            }
            //if (!cateringItem.Code.Contains(productCode))
            //{
            //    Console.WriteLine("Sorry, that product doesn't exist." );
            //}



        }




    }
}

