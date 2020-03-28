using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DinnerModel
    {
        public string Location { get; set; }
        public FamilyModel Purchaser { get; set; }
        public double Price { get; set; }
    }
}
