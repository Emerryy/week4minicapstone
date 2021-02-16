using System.Collections.Generic;
using Capstone.Classes;

namespace Capstone.Interfaces
{
    public interface IDataAccess
    {
        List<CateringItem> GetInventory();
        bool WriteLog(string type, decimal transaction, decimal balance);
    }
}
