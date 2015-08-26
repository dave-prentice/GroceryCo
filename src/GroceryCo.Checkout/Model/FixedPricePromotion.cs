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
        /// <param name="itemId">The Id of the <see cref="GroceryItem"/> to which the promotion is being offered</param>
        /// <param name="quantity">The quantity of item which qualifies for the promotion</param>
        /// <param name="price">The fixed price for the specified quantity of items</param>
        public FixedPricePromotion(string itemId, int quantity, decimal price)
        {
            ItemId = itemId;
            Quantity = quantity;
            Price = price;
        }


        /// <summary>
        /// The Id of the <see cref="GroceryItem"/> to which the promotion is being offered
        /// </summary>
        public string ItemId { get; }


        /// <summary>
        /// The quantity of items for which the promotion is valid
        /// </summary>
        public int Quantity { get; }


        /// <summary>
        /// The price for the specified quantity of the specified item
        /// </summary>
        public decimal Price { get; }


        /// <summary>
        /// The price of one <see cref="GroceryItem"/> under the terms of the promotion
        /// </summary>
        public decimal UnitPrice => decimal.Round(Price/Quantity, 2);
    }
}
