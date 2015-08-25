using GroceryCo.Checkout.Model;
using NUnit.Framework;

namespace GroceryCo.Checkout.Tests.Model
{
    internal static class FixedPricePromotionTests
    {
        [TestCaseSource(nameof(TestCases))]
        public static void Price_VariousScenarios_PriceComputedCorrectly(int quantity, decimal rate)
        {
            // Arrange
            var promotion = new FixedPricePromotion(quantity, rate);

            // Act
            var actualPrice = promotion.Price;

            //Assert
            Assert.That(actualPrice, Is.EqualTo(rate));
        }


        private static readonly TestCaseData[] TestCases = new[]
        {
            new TestCaseData(2, 3.0m)
                .SetName("Two for $3"),
            new TestCaseData(3, 3.0m)
                .SetName("Three for $3")
        };
    }
}
