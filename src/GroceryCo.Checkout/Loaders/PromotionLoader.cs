using System;
using System.Collections.Generic;
using System.Linq;
using GroceryCo.Checkout.Model;
using Newtonsoft.Json;

namespace GroceryCo.Checkout.Loaders
{
    /// <summary>
    /// Loads promotions from a JSON representation
    /// </summary>
    internal static class PromotionLoader
    {
        /// <summary>
        /// Loads all promotions from the given JSON text
        /// </summary>
        /// <param name="jsonPromotions">The JSON representation of all stock promotions</param>
        /// <param name="stockItems">A dictionary of all the unique <see cref="GroceryItem"/> in the store</param>
        /// <returns>A sequence of promotions thatthe store is currently offering</returns>
        public static IEnumerable<IPromotion> Load(string jsonPromotions, IDictionary<string, GroceryItem> stockItems)
        {
            var promotions = JsonConvert.DeserializeObject<PromotionPoco[]>(jsonPromotions);

            Func<PromotionPoco, IPromotion> promotionFactory = p =>
            {
                // Determine that the item is actually available
                if (!stockItems.ContainsKey(p.ItemId))
                {
                    throw new InvalidOperationException($"The GroceryItem {p.ItemId} is not listed in stock");
                }

                var groceryItem = stockItems[p.ItemId];

                switch (p.PromotionType)
                {
                    case PromotionType.Fixed:
                        return new FixedPricePromotion(groceryItem.Id, p.Quantity, p.Rate);

                    case PromotionType.Relative:
                        return new RelativePricePromotion(groceryItem, p.Quantity, p.Rate);

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };

            return promotions.Select(promotionFactory);
        }


        /// <summary>
        /// POCO class for the deserialization of Promotions
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
}
