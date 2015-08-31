namespace GroceryCo.Checkout.Model
{
    /// <summary>
    /// Represents an entry to be included on the receipt
    /// </summary>
    public sealed class ReceiptEntry
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="quantity">The total quantity of items purchased</param>
        /// <param name="itemDescription">The description of the item</param>
        /// <param name="unitPrice">The unit price of each item</param>
        /// <param name="totalPrice">The total price of all the items</param>
        /// <param name="promotion">True if the price was the result of a promotion</param>
        public ReceiptEntry(int quantity, string itemDescription, decimal unitPrice, decimal totalPrice, bool promotion = false)
        {
            Quantity = quantity;
            ItemDescription = itemDescription;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
            Promotion = promotion;
        }


        /// <summary>
        /// The total quantity of items purchased
        /// </summary>
        public int Quantity { get; }


        /// <summary>
        /// The description of the item
        /// </summary>
        public string ItemDescription { get; }


        /// <summary>
        /// The unit price of each item
        /// </summary>
        public decimal UnitPrice { get; }


        /// <summary>
        /// The total price of all the items
        /// </summary>
        public decimal TotalPrice { get; }


        /// <summary>
        /// True if the price was the result of a promotion
        /// </summary>
        public bool Promotion { get; }


        /// <summary>
        /// Deterines whether an instance of an object is equal to another
        /// </summary>
        /// <param name="obj">The object being compared to</param>
        /// <returns>True if the objects being compared are considered equal</returns>
        public override bool Equals(object obj)
        {
            return obj is ReceiptEntry && Equals((ReceiptEntry)obj);
        }


        /// <summary>
        /// Serves as the default hash function. Implementation courtesy of Resharper
        /// </summary>
        /// <returns>An iteger representing the hash code of the given object</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Quantity;
                hashCode = (hashCode * 397) ^ (ItemDescription?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ UnitPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ Promotion.GetHashCode();
                return hashCode;
            }
        }


        /// <summary>
        /// Determines whether the specified object is equal to the current object. Implementation courtesy of Resharper
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        private bool Equals(ReceiptEntry other)
        {
            return Quantity == other.Quantity && string.Equals(ItemDescription, other.ItemDescription) && UnitPrice == other.UnitPrice && TotalPrice == other.TotalPrice && Promotion == other.Promotion;
        }
    }
}
