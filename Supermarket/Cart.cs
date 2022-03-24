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

        public (double?, PricingRules?, string?) FindProductPrice(Product p)
        {
            if (p != null && this.products != null)
            {
                Product foundProduct = FindProduct(p);
                if (p.ProductRule == PricingRules.SimplePrice)
                {
                    return (foundProduct.ProductPrice, PricingRules.SimplePrice, "Product Price is : " + foundProduct.ProductPrice);
                }
                if (p.ProductRule == PricingRules.ThreeForSinglePrice)
                {
                    return (foundProduct.ProductPrice, PricingRules.ThreeForSinglePrice, "Get three for a single Price at : " + foundProduct.ProductPrice);
                }
                if (p.ProductRule == PricingRules.TwoAndOneFree)
                {
                    return (foundProduct.ProductPrice, PricingRules.TwoAndOneFree, "Buy two and get one free at : " + foundProduct.ProductPrice);
                }
                if (p.ProductRule == PricingRules.PoundsToOunces)
                {
                    return (foundProduct.ProductPrice, PricingRules.PoundsToOunces, "one pound cost : " + foundProduct.ProductPrice);
                }
            }
            return (null, null, null);
        }

        public double getTotal()
        {
            return 0.0;
        }

    }

}
