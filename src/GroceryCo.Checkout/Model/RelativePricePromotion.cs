namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// Represents a promotion where the total price of a given
    /// quantity of items is a function of that quantity and price of the item
    /// For example "Buy one get one free" indicates that if you buy two items
    /// the cost will be 50% of the expected total.
    /// </summary>
    internal sealed class RelativePricePromotion : IPromotion
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="groceryItem">The <see cref="GroceryItem"/> for which the promotion isvalid</param>
        /// <param name="quantity">The quantity of item which qualifies for the promotion</param>
        /// <param name="rate">The percentage of the item price to be computed</param>
        public RelativePricePromotion(GroceryItem groceryItem, int quantity, decimal rate)
        {
            Quantity = quantity;
            _rate = rate;
            Item = groceryItem;
        }


        /// <summary>
        /// The item under promotion
        /// </summary>
        public GroceryItem Item { get; set; }


        /// <summary>
        /// The Id of the <see cref="GroceryItem"/> to which this promotion applies
        /// </summary>
        public string ItemId => Item.Id;


        /// <summary>
        /// The quantity of items for which the promotion is valid
        /// </summary>
        public int Quantity { get; }


        /// <summary>
        /// The total discounted price of for the specified quantity of items
        /// </summary>
        public decimal Price => decimal.Round(Quantity * Item.Price * _rate, 2);


        /// <summary>
        /// The price of one <see cref="GroceryItem"/> under the terms of the promotion
        /// </summary>
        public decimal UnitPrice => decimal.Round(Price / Quantity, 2);


        /// <summary>
        /// The percentage of the total price for each item in this promotion
        /// </summary>
        private readonly decimal _rate;
    }
}
