using System.Linq;
using GroceryCo.Checkout.Loaders;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GroceryCo.Checkout.Tests.Loaders
{
    internal static class BasketItemLoaderTests
    {
        [Test]
        public static void Load_ValidJson_Succeeds()
        {
            var items = BasketItemLoader.Load(ValidBasketJson);

            Assert.That(items.Count(), Is.EqualTo(3));
        }


        [Test]
        public static void Load_InvalidJson_Fails()
        {
            //Arrange + Act + Assert
            Assert.Throws<JsonSerializationException>(() => BasketItemLoader.Load(InvalidBasketJson));
        }


        internal const string ValidBasketJson = "[{'id': 'Apples'}, {'id': 'Oranges'}, {'id': 'pears'}]";

        internal const string InvalidBasketJson = "{'foo': 'bar'}";
    }
}
