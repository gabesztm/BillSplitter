using ClassLibrary.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Calculate
    {
        public static void CalculateTransactions(List<TransactionModel> transactions, List<FamilyModel> families)
        {
            foreach (TransactionModel trans in transactions)
            {
                families.Find(x => x == trans.FromFamily).balance += trans.amountOfMoney;
                families.Find(x => x == trans.ToFamily).balance -= trans.amountOfMoney;
            }
        }
    }
}
