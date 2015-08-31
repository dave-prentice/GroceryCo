using GroceryCo.Checkout.Model;
using NUnit.Framework;

namespace GroceryCo.Checkout.Tests.Model
{
    internal static class FixedPricePromotionTests
    {
        [TestCaseSource(nameof(TestCases))]
        public static void Price_VariousScenarios_PriceComputedCorrectly(int quantity, decimal rate, decimal expectedUnitPrice, string expectedItemId)
        {
            // Arrange
            var promotion = new FixedPricePromotion(expectedItemId, quantity, rate);

            // Act
            var actualPrice = promotion.Price;
            var actualUnitPrice = promotion.UnitPrice;
            var actualItemId = promotion.ItemId;

            //Assert
            Assert.That(actualPrice, Is.EqualTo(rate));
            Assert.That(actualUnitPrice, Is.EqualTo(expectedUnitPrice));
            Assert.That(actualItemId, Is.EqualTo(expectedItemId));
        }


        private static readonly TestCaseData[] TestCases =
        {
            new TestCaseData(2, 3.0m, 1.5m, "foo")
                .SetName("Two for $3"),
            new TestCaseData(3, 3.0m, 1.0m, "bar")
                .SetName("Three for $3")
        };
    }
}
