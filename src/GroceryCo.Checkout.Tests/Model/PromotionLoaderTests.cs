using System.Collections.Generic;
using System.Linq;
using GroceryCo.Checkout.Loaders;
using GroceryCo.Checkout.Model;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GroceryCo.Checkout.Tests.Model
{
    internal static class PromotionLoaderTests
    {
        [Test]
        public static void Load_ValidJson_Succeeds()
        {
            // Arrange + Act
            var promotions = PromotionLoader.Load(ValidPromotionsJson, StockItems).ToArray();

            //Assert
            Assert.That(promotions.Length, Is.EqualTo(1));

            var promotion = promotions.First();

            // Two items for the price of one
            Assert.That(promotion.Quantity, Is.EqualTo(2));
            Assert.That(promotion.Price, Is.EqualTo(1.0m));
        }


        [Test]
        public static void Load_InvalidJson_Fails()
        {
            // Arrange + Act + Assert
            Assert.Throws<JsonSerializationException>(() => PromotionLoader.Load(InvalidPromotionsJson, StockItems));
        }


        private static readonly IDictionary<string, GroceryItem> StockItems = new Dictionary<string, GroceryItem>
        {
            {
                "Apple",
                new GroceryItem("Apple", 1.0m)
            }
        };


        private const string ValidPromotionsJson = "[{'itemId': 'Apple', 'quantity': 2, 'rate': 0.5, 'promotionType': 'relative'}]";


        private const string InvalidPromotionsJson = "{'foo': 'bar'}";
    }
}
