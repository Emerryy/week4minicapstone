using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        //Code|Name|Price|Type
        // This class should contain the definition for one catering item

        int quantity = 50;
        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public override string ToString()
        {
            return $"Item code {Code}, {Name}, ${Price}, {Quantity} available";

        }
    }
}
