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

        public Dictionary<string, int> scanProducts()
        {
            Dictionary<string, int> scannedProducts = new Dictionary<string, int>();
            var groupedProducts = this.products.GroupBy(
            p => p.ProductName,
            p => p.ProductName,
            (ProductName, prices) => new
            {
                Key = ProductName,
                Count = prices.Count(),
            });

            foreach (var groupProduct in groupedProducts)
            {
                scannedProducts.Add(groupProduct.Key, groupProduct.Count);
            }
            return scannedProducts;
        }

        public double getTotal()
        {
            Dictionary<string, int> scannedProducts = this.scanProducts();
            double total = 0.0;
            if (scannedProducts != null)
            {
                foreach (var scannedProduct in scannedProducts)
                {
                    var product = this.FindProduct(scannedProduct.Key);

                    // if Simple price, the unit price is already given
                    if (product.GetPricingRules() == PricingRules.SimplePrice)
                    {
                        total += product.ProductPrice * scannedProduct.Value;
                    }

                    //We assume that there is a unit price when we have more than 3 items
                    //So if I buy more than 3 product then unit will be the price / 3
                    if (product.GetPricingRules() == PricingRules.ThreeForSinglePrice)
                    {
                        if (scannedProduct.Value >= 3)
                        {
                            if (scannedProduct.Value % 3 == 0)
                            {
                                total += product.ProductPrice * scannedProduct.Value / 3;
                            }
                            else
                            {
                                total += product.ProductPrice / 3 * scannedProduct.Value;
                            }
                        }
                    }

                    //same case as previous but there is not unit price at this step
                    //as we are not able to deduce it
                    if (product.GetPricingRules() == PricingRules.TwoAndOneFree)
                    {
                        if (scannedProduct.Value >= 3)
                        {
                            if (scannedProduct.Value % 3 == 0)
                            {
                                total += product.ProductPrice * scannedProduct.Value / 3;
                            }
                        }
                    }

                    //I have unit price of pound
                    //So if I want price of ounces, I should convert Ounces to pounds
                    //and then apply the unit price 
                    if (product.GetPricingRules() == PricingRules.PoundsToOunces)
                    {
                        double newProductWeight = product.Weight;
                        if (product.Unit == WeightUnit.Ounce)
                        {
                            //we should convert Ounce weight in pound
                            newProductWeight = ConvertOuncesToPound(product.Weight);
                        }

                        total += product.ProductPrice * newProductWeight * scannedProduct.Value;
                    }
                }

            }
            return total;
        }

        // 1 pound =16 ounces 
        private double ConvertPoundsToOunces(double pound)
        {
            return pound * 16;
        }

        // 1 pound =16 ounces 
        private double ConvertOuncesToPound(double ounce)
        {
            return ounce * 1 / 16;
        }

    }

}
