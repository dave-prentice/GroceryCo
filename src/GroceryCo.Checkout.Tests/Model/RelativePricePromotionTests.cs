using GroceryCo.Checkout.Model;
using NUnit.Framework;

namespace GroceryCo.Checkout.Tests.Model
{
    internal static class RelativePricePromotionTests
    {
        [TestCaseSource(nameof(TestCases))]
        public static void Price_VariousScenarios_TotalPriceComputedCorrectly(
            int quantity,
            decimal rate,
            GroceryItem groceryItem,
            decimal expectedPrice,
            decimal expectedUnitPrice,
            string expectedItemId)
        {
            // Arrange
            var promotion = new RelativePricePromotion(groceryItem, quantity, rate);

            // Act
            var actualPrice = promotion.Price;
            var actualUnitPrice = promotion.UnitPrice;
            var actualItemId = promotion.ItemId;

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedPrice));
            Assert.That(actualUnitPrice, Is.EqualTo(expectedUnitPrice));
            Assert.That(actualItemId, Is.EqualTo(expectedItemId));
        }


        private static readonly GroceryItem TestItem = new GroceryItem("Apples", 1.0m);


        private static readonly TestCaseData[] TestCases =
        {
            new TestCaseData(2, 0.75m, TestItem, 1.5m, 0.75m, TestItem.Id)
                .SetName("Buy one Get one half price"),
            new TestCaseData(2, 0.5m, TestItem, 1.0m, 0.5m, TestItem.Id)
                .SetName("Buy one Get one free")
        };
    }
}
