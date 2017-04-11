using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsheeraSagara.Model
{
    public class Settings
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public double CowMilkPrice { get; set; }
        public double BuffaloMilkPrice { get; set; }

        public double LocalSalePrice { get; set; }
    }
}
