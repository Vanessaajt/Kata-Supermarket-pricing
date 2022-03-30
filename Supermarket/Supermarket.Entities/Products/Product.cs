using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class Product
    {
        private string _name;
        private double _price;
        private PricingRules? _rule;
        private double _quantity;
        public string ProductName
        {
            get => _name;
            set => _name = value;
        }
        public double ProductPrice
        {
            get => _price;
            set => _price = value;
        }
        public PricingRules? ProductRule
        {
            get => _rule;
            set => this._rule = value;
        }

        public double Quantity
        {
            get => _quantity;
            set => this._quantity = value;
        }

        public Product()
        {
            this._name = "";
            this._price = 0;
            this._rule = PricingRules.SimplePrice;
        }
        public Product(string name, double price, PricingRules rule, double quantity = 1.0)
        {
            this._name = name;
            this._price = price;
            this._rule = rule;
            this._quantity = quantity;
        }

        public PricingRules? GetPricingRules()
        {
            return this.ProductRule;
        }
    }
}
