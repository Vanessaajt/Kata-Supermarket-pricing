using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket;

namespace SupermarketTest
{
    [TestClass]
    public class SupermarketUnitTest
    {
        Product simpleProduct = new Product("simpleProduct", 2, PricingRules.SimplePrice);
        Product complexProduct1 = new Product("ThreeForSinglePrice", 1, PricingRules.ThreeForSinglePrice);
        Product complexProduct2 = new Product("TwoAndOneFree", 3, PricingRules.TwoAndOneFree);
        Product complexProduct3 = new Product("PoundsToOunces", 3, PricingRules.PoundsToOunces);

        Cart cart = new Cart();
        Cart SimpleCart = new Cart();
        Cart ComplexCart1 = new Cart();
        Cart ComplexCart2 = new Cart();
        Cart ComplexCart3 = new Cart();
        Cart ComplexCart4 = new Cart();
        Cart ComplexCart5 = new Cart();


        private void initCart()
        {
            cart.AddProduct(simpleProduct);
            cart.AddProduct(complexProduct1);
            cart.AddProduct(complexProduct2);
            cart.AddProduct(complexProduct3);
            cart.AddProduct(complexProduct1);
            cart.AddProduct(complexProduct2);
            cart.AddProduct(complexProduct3);
            cart.AddProduct(complexProduct1);
            cart.AddProduct(complexProduct2);

            SimpleCart.AddProduct(simpleProduct);
            SimpleCart.AddProduct(simpleProduct);

            ComplexCart1.AddProduct(complexProduct1);
            ComplexCart1.AddProduct(complexProduct1);
            ComplexCart1.AddProduct(complexProduct1);

            ComplexCart2.AddProduct(complexProduct2);
            ComplexCart2.AddProduct(complexProduct2);
            ComplexCart2.AddProduct(complexProduct2);

            ComplexCart3.AddProduct(complexProduct3);

            ComplexCart4.AddProduct(complexProduct1);
            ComplexCart4.AddProduct(complexProduct1);
            ComplexCart4.AddProduct(complexProduct1);
            ComplexCart4.AddProduct(complexProduct1);

            ComplexCart5.AddProduct(complexProduct3);
            ComplexCart5.AddProduct(complexProduct3);
        }

        [TestMethod]
        public void shouldAddAndRemoveProductFromCart()
        {
            Cart cart1 = new Cart();
            cart1.AddProduct(simpleProduct);
            Assert.AreEqual(simpleProduct, cart1.FindProduct(simpleProduct));
            cart1.RemoveProduct(simpleProduct);
            Assert.AreNotEqual(simpleProduct, cart1.FindProduct(simpleProduct));
        }

        [TestMethod]
        [DataRow("simpleProduct", 2, PricingRules.SimplePrice)]
        public void hasSimplePricingRule(string name, double price, PricingRules rule)
        {
            Assert.AreEqual(rule, simpleProduct.GetPricingRules());
        }

        [TestMethod]
        [DataRow("ThreeForSinglePrice", 1, PricingRules.ThreeForSinglePrice)]
        public void hasComplexPricingRule(string name, double price, PricingRules rule)
        {
            Assert.AreEqual(rule, complexProduct1.GetPricingRules());
        }

        [TestMethod]
        public void shouldfindProduct()
        {
            initCart();
            Assert.AreEqual("simpleProduct", cart.FindProduct(simpleProduct).ProductName);
        }

        [TestMethod]
        public void shouldGivePriceOfProduct()
        {
            initCart();
            Assert.AreEqual(2, cart.FindProductPrice(simpleProduct).Item1);
            Assert.AreEqual(3, cart.FindProductPrice(complexProduct2).Item1);
        }

        [TestMethod]
        public void shouldGiveTotalOfCart()
        {
            initCart();
            Assert.AreEqual(4, SimpleCart.getTotal());
            Assert.AreEqual(1, ComplexCart1.getTotal());
            Assert.AreEqual(3, ComplexCart2.getTotal());
            Assert.AreEqual((1.0 * 4) / 3, ComplexCart4.getTotal());
            Assert.AreEqual(3.0 * 0.25, ComplexCart3.getTotal());
            Assert.AreEqual(3.0 * 0.25 * 2, ComplexCart5.getTotal());
            Assert.AreEqual(7.5, cart.getTotal());

        }

    }
}