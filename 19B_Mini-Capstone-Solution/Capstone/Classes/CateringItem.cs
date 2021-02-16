using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        // This class should contain the definition for one catering item

        public string ProductCode { get; }
        public string ProductName { get; }
        public decimal Price { get; }
        public string ProductType { get; }
        public int Quanity { get; set; }

        public CateringItem()
        {

        }

        public CateringItem(string productCode,
            string productName,
            decimal price,
            string productType,
            int quanity)
        {
            ProductCode = productCode;
            ProductName = productName;
            Price = price;
            ProductType = productType;
            Quanity = quanity;
        }

        public override string ToString()
        {
            string result = ProductCode.PadRight(4);
            result += ProductName.PadRight(25);
            result += Price.ToString("C").PadLeft(6);
            result += " ";

            if (Quanity == 0)
            {
                result += "Sold Out!";
            }
            else
            {
                result += Quanity.ToString().PadRight(10);
            }

            return result;
        }

    }
}
