namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// Represents a promotion offered on a <see cref="GroceryItem"/>
    /// </summary>
    internal interface IPromotion
    {
        /// <summary>
        /// The quantity of the specified item which qualifies
        /// the customer for the promotion
        /// </summary>
        int Quantity { get; }


        /// <summary>
        /// The computed total price of Quantity of the specified item
        /// </summary>
        decimal Price { get; }
    }
}
