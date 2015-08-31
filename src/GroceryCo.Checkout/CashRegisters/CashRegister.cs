using System.Collections.Generic;
using System.Linq;
using GroceryCo.Checkout.Model;

namespace GroceryCo.Checkout.CashRegisters
{
    /// <summary>
    /// Implementation of a checkout algorithm using a Greedy approach
    /// </summary>
    public sealed class CashRegister
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="promotions">A sequence of all the promotions offered by the store</param>
        public CashRegister(IEnumerable<IPromotion> promotions)
        {
            _promotions = promotions ?? Enumerable.Empty<IPromotion>();
        }


        /// <summary>
        /// Processes the content of the basket and generates entries to be included
        /// on a receipt.
        /// </summary>
        /// <param name="basketContent">the sequence of <see cref="GroceryItem"/> objects to be processed</param>
        /// <returns>A sequence of <see cref="ReceiptEntry"/> objects for inclusion in a receipt</returns>
        public IEnumerable<ReceiptEntry> Process(IEnumerable<GroceryItem> basketContent)
        {
            var result = new List<ReceiptEntry>();

            // Group the items in the basket and count how many there
            // are of each
            var groupedItems = basketContent.GroupBy(i => i.Id);

            // process each type of item individually
            foreach (var itemGroup in groupedItems)
            {
                // establish promotions apply to the given Item
                // And sort them by unit price.
                var relevantPromotions = _promotions
                    .Where(p => p.ItemId == itemGroup.Key)
                    .OrderBy(p => p.UnitPrice);

                var itemsLeft = itemGroup.Count();

                // itterate through the applicable promotions
                // using the ones with most value for money (i.e lowest UnitPrice)
                // as often as possible.
                foreach (var promotion in relevantPromotions)
                {
                    while (itemsLeft >= promotion.Quantity)
                    {
                        result.Add(new ReceiptEntry(promotion.Quantity, itemGroup.Key, promotion.UnitPrice, promotion.Price, true));
                        itemsLeft = itemsLeft - promotion.Quantity;
                    }
                }

                // any remaining items do not qualify for a promotion
                // and must be paid for in full
                if (itemsLeft == 0) continue;

                var groceryItem = itemGroup.First();
                result.Add(new ReceiptEntry(itemsLeft, groceryItem.Id, groceryItem.Price, groceryItem.Price * itemsLeft));
            }

            return result;
        }


        private readonly IEnumerable<IPromotion> _promotions;
    }
}
