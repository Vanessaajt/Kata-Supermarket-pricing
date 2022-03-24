using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class Product
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public PricingRules ProductRule { get; set; }

        public Product()
        {
            ProductName = "";
            ProductPrice = 0;
            ProductRule = 0;
        }
        public Product(string name, double price, PricingRules rule)
        {
            ProductName = name;
            ProductPrice = price;
            ProductRule = rule;
        }

        public PricingRules? GetPricingRules()
        {
            return null;
        }

    }
}
