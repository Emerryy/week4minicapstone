using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class FileAccess
    {
        // all files for this application should in this directory
        // you will likley need to create it on your computer
        //cateringsystem.csv
        //Code|Name|Price|Type
        private string filePath = @"C:\Catering\cateringsystem.csv";
        private string auditPath = @"C:\Catering\log.txt";



        // This class should contain any and all details of access to files


        public List<CateringItem> GetCateringItems()
        {
            List<CateringItem> items = new List<CateringItem>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split('|');

                    CateringItem temp = new CateringItem();
                    temp.Code = values[0];
                    temp.Name = values[1];
                    temp.Price = decimal.Parse(values[2]);


                    if (values[3] == "B")
                    {
                        temp.Type = "Beverage";
                    }
                    else if (values[3] == "E")
                    {
                        temp.Type = "Entree";
                    }
                    else if (values[3] == "D")
                    {
                        temp.Type = "Dessert";
                    }
                    else if (values[3] == "A")
                    {
                        temp.Type = "Appetizer";
                    }
                    items.Add(temp);

                }
            }
            return items;
        }
        public void Audit(string log)
        {


            using (StreamWriter sw = new StreamWriter(auditPath, true))
            {
                sw.WriteLine(log);
            }
        }
    }
}
