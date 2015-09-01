using System.Collections.Generic;
using System.Linq;
using GroceryCo.Checkout.Controllers;
using GroceryCo.Checkout.Model;
using GroceryCo.Checkout.Views;
using NUnit.Framework;

namespace GroceryCo.Checkout.Tests.Controllers
{
    internal static class CheckoutControllerTests
    {
        [Test]
        public static void Checkout_CorrectViewReturned()
        {
            // Arrange
            var checkoutController = GetCheckoutController();

            // Act
            var view = checkoutController.Checkout(Enumerable.Empty<BasketItem>());

            // Assert
            Assert.That(view, Is.TypeOf<ConsoleReceiptView>());
        }


        [Test]
        public static void Checkout_CorrectReceiptItemsPassedToView()
        {
            // Arrange
            var basketItems = new[] {new BasketItem("Apples"), new BasketItem("Apples")};
            var checkoutController = GetCheckoutController();
            var expectedReceiptEntries = new[]
            {
                new ReceiptEntry(2, "Apples", 1.0m, 2.0m)
            };

            // Act
            var view = checkoutController.Checkout(basketItems);

            // Assert
            CollectionAssert.AreEqual(view.ReceiptEntries, expectedReceiptEntries);
        }


        private static CheckoutController GetCheckoutController()
        {
            return new CheckoutController(
                new Dictionary<string, GroceryItem> { {"Apples", new GroceryItem("Apples", 1.0m)} },
                Enumerable.Empty<IPromotion>());
        }
    }
}
