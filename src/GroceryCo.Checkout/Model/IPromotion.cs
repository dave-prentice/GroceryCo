namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// Represents a promotion offered on a <see cref="GroceryItem"/>
    /// </summary>
    public interface IPromotion
    {
        /// <summary>
        /// The Id of the <see cref="GroceryItem"/> to which the promotion applies
        /// </summary>
        string ItemId { get; }


        /// <summary>
        /// The quantity of the specified item which qualifies
        /// the customer for the promotion
        /// </summary>
        int Quantity { get; }


        /// <summary>
        /// The computed total price of Quantity units of the specified item
        /// </summary>
        decimal Price { get; }


        /// <summary>
        /// The price of one unit of <see cref="GroceryItem"/> accoriding to teh given promotion
        /// </summary>
        decimal UnitPrice { get; }
    }
}
