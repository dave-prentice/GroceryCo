using System.Collections.Generic;
using Newtonsoft.Json;

namespace GroceryCo.Checkout.Model
{
    internal static class GroceryItemLoader
    {
        /// <summary>
        /// Loads the currently available stock items from a JSON string representation
        /// </summary>
        /// <param name="priceListJson">A JSON representation of an array of stock items</param>
        /// <returns></returns>
        public static IEnumerable<GroceryItem> Load(string priceListJson)
        {
            return JsonConvert.DeserializeObject<GroceryItem[]>(priceListJson);
        }
    }
}
