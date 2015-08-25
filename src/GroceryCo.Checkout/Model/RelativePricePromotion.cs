namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// Represents a promotion where the total price of a given
    /// quantity of items is a function of that quantity and price of the item
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
        /// The total discounted price of for the specified quantity of items
        /// </summary>
        public decimal Price => decimal.Round(Quantity * Item.Price * _rate, 2);


        /// <summary>
        /// The percentage of the total price for each item in this promotion
        /// </summary>
        private readonly decimal _rate;


        /// <summary>
        /// The quantity of items for which the promotion is valid
        /// </summary>
        public int Quantity { get; }
    }
}
