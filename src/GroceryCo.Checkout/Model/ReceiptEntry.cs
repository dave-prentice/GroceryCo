﻿namespace GroceryCo.Checkout.Model
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


        public override bool Equals(object obj)
        {
            return obj is ReceiptEntry && Equals((ReceiptEntry)obj);
        }

        private bool Equals(ReceiptEntry other)
        {
            return Quantity == other.Quantity && string.Equals(ItemDescription, other.ItemDescription) && UnitPrice == other.UnitPrice && TotalPrice == other.TotalPrice && Promotion == other.Promotion;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Quantity;
                hashCode = (hashCode*397) ^ (ItemDescription?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ UnitPrice.GetHashCode();
                hashCode = (hashCode*397) ^ TotalPrice.GetHashCode();
                hashCode = (hashCode*397) ^ Promotion.GetHashCode();
                return hashCode;
            }
        }
    }
}
