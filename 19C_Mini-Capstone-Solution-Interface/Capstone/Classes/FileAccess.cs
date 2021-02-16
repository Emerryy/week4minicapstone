using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Interfaces;

namespace Capstone.Classes
{
    public class FileAccess : IDataAccess
    {
        // This class should contain any and all details of access to files

        private string filePath = @"C:\Catering";
        private string inventoryFile = @"cateringsystem.csv";
        private string logFile = @"log.txt";

        public List<CateringItem> GetInventory()
        {
            string inventoryFullPath = Path.Combine(filePath, inventoryFile);

            List<CateringItem> inventory = new List<CateringItem>();

            try
            {
                using (StreamReader sr = new StreamReader(inventoryFullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] split = line.Split('|');
                        CateringItem item = new CateringItem(split[0],
                            split[1],
                            decimal.Parse(split[2]),
                            split[3],
                            50);
                        inventory.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                inventory = new List<CateringItem>();
            }

            return inventory;
        }

        public bool WriteLog(string type, decimal transaction, decimal balance)
        {
            bool result = false;

            string logFullPath = Path.Combine(filePath, logFile);

            try
            {
                using (StreamWriter sw = new StreamWriter(logFullPath, true))
                {
                    string message = DateTime.Now.ToLocalTime().ToString().PadLeft(30) +
                        type.PadLeft(30) +
                        transaction.ToString("C").PadLeft(30) +
                        balance.ToString("C").PadLeft(30);
                    sw.WriteLine(message);
                }

                result = true;
            }

            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
