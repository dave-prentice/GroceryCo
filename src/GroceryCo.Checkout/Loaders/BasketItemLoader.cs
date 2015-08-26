using System.Collections.Generic;
using System.Linq;
using GroceryCo.Checkout.Model;
using Newtonsoft.Json;

namespace GroceryCo.Checkout.Loaders
{
    public static class BasketItemLoader
    {
        /// <summary>
        /// Loads the content of a customer's basket from a JSON representation
        /// </summary>
        /// <param name="basketJson"></param>
        /// <returns>A sequence of <see cref="BasketItem"/> objects</returns>
        public static IEnumerable<BasketItem> Load(string basketJson)
        {
            return JsonConvert.DeserializeObject<BasketItemPoco[]>(basketJson)
                .Select(p => new BasketItem(p.Id));
        }


        /// <summary>
        /// POCO for deserialization of <see cref="BasketItem"/> instances
        /// </summary>
        internal sealed class BasketItemPoco
        {
            /// <summary>
            /// The id of the <see cref="GroceryItem"/> which this object represents
            /// </summary>
            public string Id { get; set;}
        }
    }
}
