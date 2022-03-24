using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class Cart
    {
        public List<Product> products = new List<Product>();

        public List<Product> AddProduct(Product p)
        {
            return new List<Product>();
        }

        public List<Product> RemoveProduct(Product p)
        {
            return new List<Product>();
        }

        public Product FindProduct(Product p)
        {
            return new Product();
        }


        public (double, PricingRules, string) FindProductPrice(Product p)
        {
            return (0, PricingRules.SimplePrice, "");
        }

        public double getTotal()
        {
            return 0.0;
        }

    }

}
