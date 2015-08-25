using System.Linq;
using GroceryCo.Checkout.Model;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GroceryCo.Checkout.Tests.Model
{
    internal static class GroceryItemLoaderTests
    { 
        [Test]
        public static void Load_ValidJson_Succeeds()
        {
            //Arrange + Act
            var stockItems = GroceryItemLoader.Load(ValidItemsJson)
                .ToArray();

            //Assert
            Assert.That(stockItems.Length, Is.EqualTo(2));
        }


        [Test]
        public static void Load_InvalidJson_Fails()
        {
            //Arrange + Act + Assert
            Assert.Throws<JsonSerializationException>(() => GroceryItemLoader.Load(InvalidItemsJson));
        }


        private const string ValidItemsJson = "[{'id': 'Apple', 'price': 0.50}, {id: 'Orange', 'price': 1.0}]";

        private const string InvalidItemsJson = "{'foo': 'bar'}";
    }
}
