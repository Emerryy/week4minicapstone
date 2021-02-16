using Capstone.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.Classes
{
    public class DatabaseAccess : IDataAccess
    {
        string sql_GetInventory = "SELECT * FROM inventory;";
        string sql_WriteLog = "INSERT INTO log (logtime, description, startamount, endamount)" +
            "VALUES(@logtime, @description, @startamount, @endamount)";

        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CateringSystem;Integrated Security=True";

        public List<CateringItem> GetInventory()
        {
            List<CateringItem> items = new List<CateringItem>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_GetInventory, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        string code = Convert.ToString(reader["code"]);
                        string name = Convert.ToString(reader["name"]);
                        decimal price = Convert.ToDecimal(reader["price"]);
                        string type = Convert.ToString(reader["type"]);
                        CateringItem item = new CateringItem(code, name, price, type, 50);
                        items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                items = new List<CateringItem>();

            }
            return items;

        }

        public bool WriteLog(string description, decimal startAmount, decimal endAmount)
        {
            bool result = false;
            int rowCount = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_WriteLog, conn);

                    cmd.Parameters.AddWithValue("@logtime", DateTime.Now.ToLocalTime());
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@startamount", startAmount);
                    cmd.Parameters.AddWithValue("@endamount", endAmount);

                    rowCount = cmd.ExecuteNonQuery();

                    if (rowCount > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;

            }
            return result;
        }
    }
}
