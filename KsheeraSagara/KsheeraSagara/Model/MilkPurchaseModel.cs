using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsheeraSagara.Model
{
    public class MilkPurchaseModel
    {
        public int CardNumber { get; set; }

        public double Fat { get; set; }

        public double Litre { get; set; }

        public double Price { get; set; }

        public SessionModel Session { get; set; }

        public DateTime Date { get; set; }
    }
}
