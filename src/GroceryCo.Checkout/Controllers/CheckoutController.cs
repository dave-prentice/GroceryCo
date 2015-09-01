using System;
using System.Collections.Generic;
using System.Linq;
using GroceryCo.Checkout.CashRegisters;
using GroceryCo.Checkout.Model;
using GroceryCo.Checkout.Views;

namespace GroceryCo.Checkout.Controllers
{
    public sealed class CheckoutController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="priceList">The stores current price list as a sequence of <see cref="GroceryItem"/></param>
        /// <param name="promotions">A sequence of current promotions</param>
        public CheckoutController(IDictionary<string, GroceryItem> priceList, IEnumerable<IPromotion> promotions)
        {
            if (promotions == null) { throw new ArgumentNullException(nameof(promotions));}
            if (priceList == null) { throw new ArgumentNullException(nameof(priceList));}

            _priceList = priceList;
            _promotions = promotions;
        }


        /// <summary>
        /// Checks out each item in the basket, taking into account any
        /// promotions available
        /// </summary>
        /// <returns>an <see cref="IReceiptView"/> instance representing the view to be rendered</returns>
        public IReceiptView Checkout(IEnumerable<BasketItem> basket)
        {
            // Use the CashRegister to computethe receipt entries
            var register = new CashRegister(_promotions);

            //Lookup prices for all the grocery items in the basket
            var groceryItems = basket.Select(i => _priceList[i.Id]);

            //Generate receipt entries
            var receiptEntries = register.Process(groceryItems);

            // Instantiate the view and render it
            return new ConsoleReceiptView(receiptEntries);
        }


        private readonly IDictionary<string, GroceryItem> _priceList;

        private readonly IEnumerable<IPromotion> _promotions;
    }
}
