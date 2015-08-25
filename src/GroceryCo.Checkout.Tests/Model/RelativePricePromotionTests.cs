using System.Collections;
using System.Collections.Generic;
using GroceryCo.Checkout.Model;
using NUnit.Framework;

namespace GroceryCo.Checkout.Tests.Model
{
    internal static class RelativePricePromotionTests
    {
        [TestCaseSource(nameof(TestCases))]
        public static void Price_VariousScenarios_TotalPriceComputedCorrectly(int quantity, decimal rate, GroceryItem groceryItem, decimal expectedPrice)
        {
            // Arrange
            var promotion = new RelativePricePromotion(groceryItem, quantity, rate);

            // Act
            var actualPrice = promotion.Price;

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedPrice));
        }


        private static readonly GroceryItem TestItem = new GroceryItem {Id = "Apples", Price = 1.0m};


        private static readonly TestCaseData[] TestCases = new []
        {
            new TestCaseData(2, 0.75m,TestItem, 1.5m)
                .SetName("Buy one Get one half price"),
            new TestCaseData(2, 0.5m,TestItem, 1.0m)
                .SetName("Buy one Get one free")
        };
    }
}
