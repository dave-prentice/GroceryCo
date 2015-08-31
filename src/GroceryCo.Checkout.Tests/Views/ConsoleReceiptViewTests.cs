using System.Collections.Generic;
using GroceryCo.Checkout.Model;
using GroceryCo.Checkout.Views;
using NUnit.Framework;

namespace GroceryCo.Checkout.Tests.Views
{
    internal static class ConsoleReceiptViewTests
    {
        [TestCaseSource(nameof(TestData))]
        public static void GetReceiptTotal_NumerousItems_ComputesCorrectTotal(IEnumerable<ReceiptEntry> receiptEntries,
            decimal expectedTotal)
        {
            // Arrange + Act
            var actualTotal = ConsoleReceiptView.GetReceiptTotoal(receiptEntries);

            // Assert
            Assert.That(actualTotal, Is.EqualTo(expectedTotal));
        }


        /// <summary>
        /// Test data for the ConsoleReceiptViewTests class
        /// </summary>
        private static readonly TestCaseData[] TestData =
        {
            new TestCaseData(new[]
            {
                new ReceiptEntry(1, "foo", 1.0m, 1.0m),
            },
                1.0m)
                .SetName("Single item total is correct"),

            new TestCaseData(new[]
            {
                new ReceiptEntry(1, "foo", 1.0m, 1.0m),
                new ReceiptEntry(1, "foo", 1.0m, 1.0m),
                new ReceiptEntry(1, "foo", 1.0m, 1.0m),
                new ReceiptEntry(1, "foo", 1.0m, 1.0m),
                new ReceiptEntry(1, "foo", 1.0m, 1.0m),
                new ReceiptEntry(1, "foo", 1.0m, 1.0m),
            },
                6.0m)
                .SetName("Multiple item total is correct"),
        };
    }
}
