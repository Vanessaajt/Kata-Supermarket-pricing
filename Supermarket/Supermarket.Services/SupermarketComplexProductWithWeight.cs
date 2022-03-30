using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class SupermarketComplexProductWithWeight : SupermarketService
    {
        public SupermarketComplexProductWithWeight() :
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
                total += product.ProductPrice * scannedProduct.Value;
            }
            return total;
        }

    }

}
