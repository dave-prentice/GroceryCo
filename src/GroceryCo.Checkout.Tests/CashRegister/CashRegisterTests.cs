using System.Collections.Generic;
using System.Linq;
using GroceryCo.Checkout.Model;
using NUnit.Framework;

namespace GroceryCo.Checkout.Tests.CashRegister
{
    /// <summary>
    /// Test fixture for the <see cref="CashRegister"/> class covering some common scenarios
    /// </summary>
    internal static class CashRegisterTests
    {
        [Test]
        public static void Process_MultipleItemTypesNoPromotions_CorrectReceiptEntriesMade()
        {
            // Arrange
            var register = new Checkout.CashRegister.CashRegister(Enumerable.Empty<IPromotion>());
            var groceryItems = new[]
            {
                new GroceryItem("Apples", 1.0m),
                new GroceryItem("Apples", 1.0m),
                new GroceryItem("Oranges", 2.0m),
                new GroceryItem("Oranges", 2.0m),
            };

            // Act
            var receiptEntries = register.Process(groceryItems).ToArray();

            // Assert
            Assert.That(receiptEntries.Count(), Is.EqualTo(2));

            //Test the receipt entry for apples
            var applesEntry = receiptEntries.First(e => e.ItemDescription == "Apples");
            Assert.That(applesEntry.Quantity, Is.EqualTo(2));
            Assert.That(applesEntry.UnitPrice, Is.EqualTo(1.0m));
            Assert.That(applesEntry.TotalPrice, Is.EqualTo(2.0m));
            Assert.That(applesEntry.Promotion, Is.False);

            //Test the receipt entry for oranges
            var orangesEntry = receiptEntries.First(e => e.ItemDescription == "Oranges");
            Assert.That(orangesEntry.Quantity, Is.EqualTo(2));
            Assert.That(orangesEntry.UnitPrice, Is.EqualTo(2.0m));
            Assert.That(orangesEntry.TotalPrice, Is.EqualTo(4.0m));
            Assert.That(orangesEntry.Promotion, Is.False);
        }


        [TestCaseSource(nameof(TestData))]
        public static void Process_OneItemTypeOnePromotion_CorrectReceiptEntriesMade(
            string itemId,
            int quantity,
            decimal unitPrice,
            IEnumerable<IPromotion> promotions,
            IEnumerable<ReceiptEntry> expectedReceiptEntreEntries)
        {
            // Arrange
            var items = GetItems(itemId, quantity, unitPrice).ToList();

            var register = new Checkout.CashRegister.CashRegister(promotions);

            // Act
            var actualReceiptEntries = register.Process(items).ToArray();

            // Assert
            CollectionAssert.AreEquivalent(actualReceiptEntries, expectedReceiptEntreEntries);
        }


        /// <summary>
        /// Test data to exercise the CashRegister class wth various promotional offers
        /// </summary>
        private static readonly TestCaseData[] TestData =
        {

            new TestCaseData(
                "Apples",
                1,
                1.0m,
                new IPromotion[] {new FixedPricePromotion("Apples", 3, 2.0m)},
                new[] {new ReceiptEntry(1, "Apples", 1.0m, 1.0m)})
                .SetName("One apple with a '3 for $2' promotion"),

            new TestCaseData(
                "Apples",
                1,
                1.0m,
                new IPromotion[] {new RelativePricePromotion(GetItem("Apples", 1), 2, 0.5m)},
                new[] {new ReceiptEntry(1, "Apples", 1.0m, 1.0m)})
                .SetName("One apple with a 'buy one get one free' promotion"),

            new TestCaseData(
                "Apples",
                2,
                1.0m,
                new IPromotion[] {new FixedPricePromotion("Apples", 3, 2.0m)},
                new[] {new ReceiptEntry(2, "Apples", 1.0m, 2.0m)})
                .SetName("Two apples with a '3 for $2' promotion"),

            new TestCaseData(
                "Apples",
                2,
                1.0m,
                new IPromotion[] {new RelativePricePromotion(GetItem("Apples", 1), 2, 0.5m)},
                new[] {new ReceiptEntry(2, "Apples", 0.5m, 1.0m, true)})
                .SetName("Two apples with a 'buy one get one free' promotion"),

            new TestCaseData(
                "Apples",
                3,
                1.0m,
                new IPromotion[] {new FixedPricePromotion("Apples", 3, 2.0m)},
                new[] {new ReceiptEntry(3, "Apples", 0.67m, 2.0m, true)})
                .SetName("Three apples with a '3 for $2' promotion"),

            new TestCaseData(
                "Apples",
                4,
                1.0m,
                new IPromotion[] {new FixedPricePromotion("Apples", 3, 2.0m)},
                new[]
                {
                    new ReceiptEntry(3, "Apples", 0.67m, 2.0m, true),
                    new ReceiptEntry(1, "Apples", 1.0m, 1.0m)
                })
                .SetName("Four apples with a '3 for $2' promotion")
        };


        /// <summary>
        /// Utility method for creating test data
        /// </summary>
        /// <param name="itemId">The id of the item to create</param>
        /// <param name="quantity">The quanitiy of items to create</param>
        /// <param name="unitPrice">The unit cost of each item</param>
        /// <returns>A sequence of <see cref="GroceryItem"/></returns>
        private static IEnumerable<GroceryItem> GetItems(string itemId, int quantity, decimal unitPrice)
        {
            for (var i = 0; i< quantity; i++)
            {
                yield return GetItem(itemId, unitPrice);
            }
        }


        /// <summary>
        /// Utility method for generating a single <see cref="GroceryItem"/>
        /// </summary>
        /// <param name="itemId">The id of the item to create</param>
        /// <param name="unitPrice">The unit cost of each item</param>
        /// <returns></returns>
        private static GroceryItem GetItem(string itemId, decimal unitPrice)
        {
            return new GroceryItem(itemId, unitPrice);
        }
    }
}
