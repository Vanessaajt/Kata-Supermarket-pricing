using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class ComplexProductWithWeight : Product
    {
        private double _weight;
        private WeightUnit _unit;
        public double Weight 
        { 
            get => _weight;
            set => _weight = value; 
        }
        public WeightUnit Unit 
        {
            get => _unit;
            set => _unit = value;
        }

        public ComplexProductWithWeight() : base()
        {

        }

        public ComplexProductWithWeight(string name, double price, PricingRules rule, double weight, WeightUnit unit)
        {
            this.ProductName = name;
            this.ProductPrice = price;
            this.ProductRule = rule;
            this._weight = weight;
            this._unit = unit;
        }
    }
}
