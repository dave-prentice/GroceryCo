namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// Describes whether a promotion offers a fixed price per quantity
    /// of item or a price relative to the item price
    /// </summary>
    internal enum PromotionType
    {
        /// <summary>
        /// The promotion offers a fixed price per quantity of item
        /// </summary>
        Fixed,


        /// <summary>
        /// The promotion offers a relative price as a function of the unit price and quantity of an item
        /// </summary>
        Relative
    }
}
