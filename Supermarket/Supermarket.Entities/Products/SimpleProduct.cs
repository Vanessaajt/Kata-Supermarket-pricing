using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class SimpleProduct : Product
    {
        public SimpleProduct(): base()
        {

        }
        public SimpleProduct(string name, double price, PricingRules rule, double quantite =1.0)
            : base(name, price, rule, quantite)
        {

        }

    }
}
