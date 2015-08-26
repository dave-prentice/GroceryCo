namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// Represents an item in stock in the grocery store
    /// </summary>
    public sealed class GroceryItem
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        public GroceryItem(string id, decimal price)
        {
            Id = id;
            Price = price;
        }


        /// <summary>
        /// The unique ID for the grocery item
        /// </summary>
        public string Id { get; }


        /// <summary>
        /// The unit price for one Item
        /// </summary>
        public decimal Price { get; }
    }
}
