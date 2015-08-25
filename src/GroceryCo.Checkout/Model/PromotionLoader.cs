using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace GroceryCo.Checkout.Model
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
        /// <returns></returns>
        public static IEnumerable<IPromotion> Load(string jsonPromotions, IDictionary<string, GroceryItem> stockItems)
        {
            var promotions = JsonConvert.DeserializeObject<PromotionPoco[]>(jsonPromotions);

            Func<PromotionPoco, IPromotion> promotionFactory = p =>
            {
                switch (p.PromotionType)
                {
                    case PromotionType.Fixed:
                        return new FixedPricePromotion(p.Quantity, p.Rate);

                    case PromotionType.Relative:

                        if (!stockItems.ContainsKey(p.ItemId))
                        {
                            throw new InvalidOperationException($"The GroceryItem {p.ItemId} is not listed in stock");
                        }

                        return new RelativePricePromotion(stockItems[p.ItemId], p.Quantity, p.Rate);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };

            return promotions.Select(promotionFactory);
        }
    }
}
