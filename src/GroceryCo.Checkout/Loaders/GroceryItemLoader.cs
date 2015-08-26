using System.Collections.Generic;
using System.Linq;
using GroceryCo.Checkout.Model;
using Newtonsoft.Json;

namespace GroceryCo.Checkout.Loaders
{
    internal static class GroceryItemLoader
    {
        /// <summary>
        /// Loads the currently available stock items from a JSON string representation
        /// </summary>
        /// <param name="priceListJson">A JSON representation of an array of stock items</param>
        /// <returns>A sequence of <see cref="GroceryItem"/> objects</returns>
        public static IEnumerable<GroceryItem> Load(string priceListJson)
        {
            return JsonConvert.DeserializeObject<GroceryItemPoco[]>(priceListJson)
                .Select(p => new GroceryItem(p.Id, p.Price));
        }


        /// <summary>
        /// Poco class for deserializing <see cref="GroceryItem"/> instances
        /// </summary>
        internal sealed class GroceryItemPoco
        {
            /// <summary>
            /// The unique ID for the grocery item
            /// </summary>
            public string Id { get; set; }


            /// <summary>
            /// The unit price for one Item
            /// </summary>
            public decimal Price { get; set; }
        }
    }
}
