using System;
using System.Security.Policy;

namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// A promotion representing a fixed price for a quantity of <see cref="GroceryItem"/>
    /// for example a promotion which may be stated as "Three for $2.00"
    /// </summary>
    internal sealed class FixedPricePromotion : IPromotion
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="quantity">The quantity of item which qualifies for the promotion</param>
        /// <param name="price">The fixed price for the specified quantity of items</param>
        public FixedPricePromotion(int quantity, decimal price)
        {
            Quantity = quantity;
            Price = price;
        }


        /// <summary>
        /// The price for the specified quantity of the specified item
        /// </summary>
        public decimal Price { get; }


        /// <summary>
        /// The quantity of items for which the promotion is valid
        /// </summary>
        public int Quantity { get; }
    }
}
