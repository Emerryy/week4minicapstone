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
        // NO instances of Console.ReadLine or Console.WriteLIne should be
        // in any other class.

        //(1) Display Catering Items
        //(2) Order
        //(3) Quit

        //(1) Add Money
        //(2) Select Products
        //(3) Complete Transaction
        //Current Account Balance: $20.00

        

        private Catering catering = new Catering();
        private Change change = new Change();

        public void RunInterface()
        {
            bool done = false;
            while (!done)
            {
                //Console.WriteLine("This is the UserInterface");
                //Console.ReadLine();
                DisplayMenu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListItems();
                        break;

                    case "2":
                        OrderMenu();
                        break;

                    case "3":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option, using only the number of the option");
                        break;
                }
            }
            void DisplayMenu()
            {
                Console.WriteLine("1) Display Catering Items");
                Console.WriteLine("2) Order");
                Console.WriteLine("3) Quit");
            }

            void OrderMenu()
            {
                Console.WriteLine("1) Add Money");
                Console.WriteLine("2) Select Products");
                Console.WriteLine("3) Complete Transaction");
                Console.WriteLine("Your account balance is: $" + catering.AccountBalance);
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddMoney();
                        break;

                    case "2":
                        ListItems();
                        CustOrder();

                        break;

                    case "3":
                        CompleteTransaction(); 

                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option, using only the number of the option");
                        break;
                }
            }

            void ListItems()
            {
                Console.WriteLine();
                CateringItem[] items = catering.GetCateringItems();
                Console.WriteLine("The available catering options are:");
                foreach (CateringItem item in items)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

            }

            void CustOrder()
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the product code you'd like to order");
                string productCode = Console.ReadLine();
                Console.WriteLine("Please tell me the amount of that product you'd like");
                int quantity = int.Parse(Console.ReadLine());
                

                catering.Update(productCode, quantity);
                
                Console.WriteLine();
                OrderMenu();
            }

            void AddMoney()
            {
                Console.WriteLine();
                Console.WriteLine("Your current account balance is $" + catering.AccountBalance);
                Console.WriteLine("Using only whole dollar amounts and not exceeding $5000 for your account balance, how much would you like to add?");
                decimal addMoney = decimal.Parse(Console.ReadLine());
                if (addMoney % 1 != 0)
                {
                    Console.WriteLine("Sorry, you can only add whole dollar amounts");
                    Console.WriteLine();


                }
                else if (catering.AccountBalance + addMoney > 5000.00M)
                {
                    Console.WriteLine("Sorry, your account balance can't exceed $5000");
                    Console.WriteLine();

                }
                else
                {
                catering.AccountBalance += addMoney;
                }
                Console.WriteLine();
                OrderMenu();
            }

            void CompleteTransaction()
            {
                Console.WriteLine();
                Console.WriteLine("Your change today is $" + catering.AccountBalance);
                Console.WriteLine(change.GiveChange(catering));
                Console.WriteLine();
              
            }

        }
    }
}
