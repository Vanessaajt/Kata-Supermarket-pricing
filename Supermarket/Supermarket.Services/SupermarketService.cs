using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class SupermarketService
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
     
        private double ConvertPoundsToOunces(double pound)
        {
            return pound * 16;
        }

        // 1 pound =16 ounces 
        private double ConvertOuncesToPound(double ounce)
        {
            return ounce * 1 / 16;
        }

        public virtual double getTotal(Dictionary<string, double> scannedProducts)
        {
            return 0;
        }

        public Dictionary<string, double> scanProducts()
        {
            Dictionary<string, double> scannedProducts = new Dictionary<string, double>();
            var groupedProducts = this.products.GroupBy(
            p => p.ProductName,
            p => p.Quantity,
            (ProductName, quantities) => new
            {
                Key = ProductName,
                Quantities = quantities.Sum()
            });

            foreach (var groupProduct in groupedProducts)
            {
                scannedProducts.Add(groupProduct.Key, groupProduct.Quantities);
            }
            return scannedProducts;
        }

        //public double getTotalOfComplexProductWithoutWeight1()
        //{
        //    Dictionary<string, double> scannedProducts = this.scanProducts();
        //    double total = 0.0;
        //    if (scannedProducts != null)
        //    {
        //        foreach (var scannedProduct in scannedProducts)
        //        {
        //            var product = this.FindProduct(scannedProduct.Key);
        //            double productPrice = product.ProductPrice;
        //            double productQuantity = scannedProduct.Value;

        //            //We assume that there is a unit price when we have more than 3 items
        //            //So if I buy more than 3 product then unit will be the price / 3
        //            if (product.GetPricingRules() == PricingRules.ThreeForSinglePrice)
        //            {
        //                if (scannedProduct.Value >= 3)
        //                {
        //                    if (scannedProduct.Value % 3 == 0)
        //                    {
        //                        total += productPrice * productQuantity / 3;
        //                    }
        //                    else
        //                    {
        //                        total += productPrice * productQuantity / 3 + (productPrice / 3* productQuantity % 3);
        //                    }
        //                }
        //            }
        //            total += product.ProductPrice * scannedProduct.Value;
        //        }
        //    }
        //    return total;
        //}

        public double getTotalOfComplexProductWithoutWeight2()
        {
            Dictionary<string, double> scannedProducts = this.scanProducts();
            double total = 0.0;
            if (scannedProducts != null)
            {
                foreach (var scannedProduct in scannedProducts)
                {
                    var product = this.FindProduct(scannedProduct.Key);
                    double productPrice = product.ProductPrice;
                    double productQuantity = scannedProduct.Value;

                    //We assume that there is a unit price when we have more than 3 items
                    //So if I buy more than 3 product then unit will be the price / 3
                    if (product.GetPricingRules() == PricingRules.ThreeForSinglePrice)
                    {
                        if (scannedProduct.Value >= 3)
                        {
                            if (scannedProduct.Value % 3 == 0)
                            {
                                total += productPrice * productQuantity / 3;
                            }
                            else
                            {
                                total += productPrice * productQuantity / 3 + (productPrice / 3 * productQuantity % 3);
                            }
                        }
                    }
                    total += product.ProductPrice * scannedProduct.Value;
                }
            }
            return total;
        }

    }

}
