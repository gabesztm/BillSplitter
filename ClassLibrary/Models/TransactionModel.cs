using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class TransactionModel
    {
        public double amountOfMoney{ get; set; }
        public FamilyModel FromFamily{ get; set; }
        public FamilyModel ToFamily{ get; set; }
    }
}
