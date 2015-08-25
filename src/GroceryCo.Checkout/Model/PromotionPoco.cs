namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// Poco class for the an item promotion
    /// </summary>
    internal sealed class PromotionPoco
    {
        /// <summary>
        /// The quantity of <see cref="GroceryItem"/> required to qualify for the promotion
        /// </summary>
        public int Quantity { get; set; }


        /// <summary>
        /// The Id of the item to which the promotion applies
        /// </summary>
        public string ItemId { get; set; }


        /// <summary>
        /// The price of Quantity items given the prevailing promotion type
        /// </summary>
        public decimal Rate { get; set; }


        /// <summary>
        /// The <see cref="PromotionType"/> (fixed or variable) of the given promotion
        /// </summary>
        public PromotionType PromotionType { get; set; }
    }
}
