using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class SupermarketComplexProductWithoutWeight : SupermarketService
    {
        public SupermarketComplexProductWithoutWeight() :
            base()
        {

        }

        public override double getTotal(Dictionary<string, double> scannedProducts)
        {
            //Dictionary<string, double> scannedProducts = this.scanProducts();
            double total = 0.0;

            foreach (var scannedProduct in scannedProducts)
            {
                var product = this.FindProduct(scannedProduct.Key);
                double productPrice = product.ProductPrice;
                double productQuantity = scannedProduct.Value;

                //We assume that there is a unit price when we have more than 3 items
                //So if I buy more than 3 product then unit will be the price / 3
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

                total += product.ProductPrice * scannedProduct.Value;
            }

            return total;
        }

    }

}
