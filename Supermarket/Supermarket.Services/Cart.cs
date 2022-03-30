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
            return this.products.Find(x => x.ProductName.Equals(ProductName)) ?? new Product();
        }


        public (double?, PricingRules?) FindProductPrice(Product p)
        {
            if (p != null && this.products != null)
            {
                Product foundProduct = FindProduct(p);
                return foundProduct != null ?(foundProduct.ProductPrice, PricingRules.SimplePrice):
                    (null, null);
            }
            return (null, null);
        }

    }

}
