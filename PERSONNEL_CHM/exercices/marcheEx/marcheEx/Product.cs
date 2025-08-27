using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marcheEx
{
    public class Product
    {
        public int Location { get; set; }
        public string Producer { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public double PricePerUnit { get; set; }
    }
}
