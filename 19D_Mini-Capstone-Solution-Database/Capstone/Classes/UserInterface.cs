using Capstone.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere
        // ALL instances of Console.ReadLine and Console.WriteLine should 
        // be in this class.


        private IDataAccess da;
        private Catering catering;

        public void RunInterface()
        {

            Console.WriteLine("Use database? (no/YES)");
            string userSelection = Console.ReadLine();

            if (userSelection == "" ||
                userSelection.ToUpper().StartsWith('Y'))
            {
                da = new DatabaseAccess();
                catering = new Catering(da);
            }
            else
            {
                da = new FileAccess();
                catering = new Catering(da);
            }

            bool done = false;
            while (!done)
            {
                string result = DisplayMainMenu();

                switch (result.ToLower())
                {
                    case "1":
                        DisplayInventory();
                        break;

                    case "2":
                        PurchaseMenu();
                        break;

                    case "3":
                        done = true;
                        continue;

                    default:
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
            }
            return;
        }

        private string DisplayMainMenu()
        {
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");

            return Console.ReadLine();
        }

        private void DisplayInventory()
        {
            CateringItem[] inventory = catering.GetInventory();

            foreach (CateringItem item in inventory)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            return;
        }

        private void PurchaseMenu()
        {
            catering.ClearPurchases();

            bool done = false;
            while (!done)
            {
                string result = DisplayPurchaseMenu();

                switch (result.ToLower())
                {
                    case "1":
                        AddMoney();
                        break;

                    case "2":
                        SelectProduct();
                        break;

                    case "3":
                        CompleteTransaction();
                        done = true;
                        continue;

                    default:
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
            }
            return;
        }

        private string DisplayPurchaseMenu()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine("Current Account Balance: " + catering.Balance.ToString("C"));

            return Console.ReadLine(); ;
        }

        private void AddMoney()
        {
            Console.WriteLine("Amount of money to add");
            string userinput = Console.ReadLine();
            string result = catering.AddMoney(userinput);

            if (result == "")
            {
                Console.WriteLine("Money added.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine();
            }

            return;
        }

        private void SelectProduct()
        {
            Console.WriteLine("Enter Product code.");
            string product = Console.ReadLine().Trim().ToUpper();

            Console.WriteLine("How many of this item?");
            string quanity = Console.ReadLine().Trim();

            Console.WriteLine();

            if (!catering.IsProductValid(product))
            {
                Console.WriteLine("Not a valid product");
            }
            else if (catering.Quanity(quanity) == 0M)
            {
                Console.WriteLine("Quanity is not valid.");
            }
            else if (catering.IsSoldOut(product))
            {
                Console.WriteLine("Product is sold out.");
            }
            else if (!catering.IsSufficientQuanity(product, quanity))
            {
                Console.WriteLine("Not enough of this product for request.");
            }
            else if (!catering.IsSufficientFunds(product, quanity))
            {
                Console.WriteLine("Not enough money for request.");
            }
            else
            {
                catering.MakePurchase(product, quanity);
            }   
        }

        private void CompleteTransaction()
        {
            CateringItem[] purchases = catering.GetPurchases();

            Console.WriteLine();

            foreach (CateringItem item in purchases)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Change is " + catering.Balance.ToString("C"));


            if (catering.Balance > 0M)
            {
                Console.WriteLine();
                string changeMessage = catering.MakeChange();
                Console.WriteLine(changeMessage);
            }

            Console.WriteLine();

            return;
        }
    }
}
