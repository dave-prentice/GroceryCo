namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// Represents an item in a customer's basket
    /// </summary>
    internal sealed class BasketItem
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="itemId"></param>
        public BasketItem(string itemId)
        {
            Id = itemId;
        }


        /// <summary>
        /// The id of the <see cref="GroceryItem"/> which this object represents
        /// </summary>
        public string Id { get; }
    }
}
