using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Change
    {
        FileAccess fileAccess = new FileAccess();




        public string GiveChange(Catering catering)
        {
            int nickel = 0;
            int dime = 0;
            int quarter = 0;
            int oneDollar = 0;
            int fiveDollar = 0;
            int tenDollar = 0;
            int twentyDollar = 0;
            decimal temp = catering.AccountBalance;



            while (catering.AccountBalance > 0)
            {
                if (catering.AccountBalance >= 20)
                {
                    twentyDollar++;
                    catering.AccountBalance -= 20;

                }
                else if (catering.AccountBalance >= 10)
                {
                    tenDollar++;
                    catering.AccountBalance -= 10;
                }
                else if (catering.AccountBalance >= 5)
                {
                    fiveDollar++;
                    catering.AccountBalance -= 5;
                }
                else if (catering.AccountBalance >= 1)
                {
                    oneDollar++;
                    catering.AccountBalance -= 1;
                }
                else if (catering.AccountBalance >= .25M)
                {
                    quarter++;
                    catering.AccountBalance -= .25M;
                }
                else if (catering.AccountBalance >= .10M)
                {
                    dime++;
                    catering.AccountBalance -= .10M;
                }
                else if (catering.AccountBalance >= .05M)
                {
                    nickel++;
                    catering.AccountBalance -= .05M;
                }

            }
            fileAccess.Audit($"{DateTime.Now} GIVE CHANGE: ${temp} ${catering.AccountBalance}");
            return $"You were given {twentyDollar} 20's, {tenDollar} 10's, {fiveDollar} 5's, {oneDollar} 1's, {quarter} quarters, {dime} dimes, and {nickel} nickels. Thanks!";

        }

    }
}
