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
        public double Weight { get; set; }
        public WeightUnit Unit { get; set; }

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

        public Product(string name, double price, PricingRules rule, double weight, WeightUnit unit)
        {
            ProductName = name;
            ProductPrice = price;
            ProductRule = rule;
            Weight = weight;
            Unit = unit;
        }

        public PricingRules? GetPricingRules()
        {
            return this.ProductRule;
        }

    }
}
