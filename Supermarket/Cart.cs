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
            this.products.Add(p);
            return this.products;
        }

        public List<Product> RemoveProduct(Product p)
        {
            this.products.Remove(p);
            return this.products;
        }

        public Product FindProduct(Product p)
        {
            return FindProduct(p.ProductName);
        }

        public Product FindProduct(string ProductName)
        {
            return this.products.Find(x => x.ProductName.Equals(ProductName)) ?? new Product("", 0.0, PricingRules.SimplePrice);
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
