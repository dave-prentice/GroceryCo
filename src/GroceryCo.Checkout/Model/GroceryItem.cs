namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// Poco for a grocery item
    /// </summary>
    public sealed class GroceryItem
    {
        /// <summary>
        /// The unique ID for the grocery item
        /// </summary>
        public string Id { get; set; }


        /// <summary>
        /// The unit price for one Item
        /// </summary>
        public decimal Price { get; set; }
    }
}
