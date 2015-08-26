﻿using System;
using System.Collections.Generic;
using System.Linq;
using GroceryCo.Checkout.Model;

namespace GroceryCo.Checkout.Views
{
    /// <summary>
    /// A view which renders a collection or <see cref="ReceiptEntry"/> objects to the console
    /// </summary>
    internal sealed class ConsoleReceiptView
    {
        /// <summary>
        /// Renders a collection of <see cref="ReceiptEntry"/> objects to the console
        /// </summary>
        /// <param name="receiptEntries"></param>
        public void Render(IEnumerable<ReceiptEntry> receiptEntries)
        {
            var enumeratedEntries = receiptEntries as ReceiptEntry[] ?? receiptEntries.ToArray();
            var receiptTotal = enumeratedEntries.Sum(e => e.TotalPrice);

            foreach (var entry in enumeratedEntries)
            {
                // Lay out a receipt entry
                var description = $"{entry.Quantity} {entry.ItemDescription} @ ${entry.UnitPrice.ToString("N2")} ea";
                var totalPrice = $"${entry.TotalPrice.ToString("N2")}";
                var promotion = entry.Promotion ? $"(promotion ${entry.UnitPrice.ToString("N2")} ea)" : string.Empty;

                var receiptEntry = string.Concat(
                    description.PadRight(ReceiptWidth - totalPrice.Length),
                    totalPrice);

                // Write the receipt entry to the console
                Console.WriteLine(receiptEntry);


                // Optionally write promotional text to the console
                if (entry.Promotion && promotion != string.Empty)
                {
                    Console.WriteLine(promotion);
                }
            }

            // Compute and render the total amount
            var totalEntry = $"${receiptTotal.ToString("N2")}";
            Console.WriteLine(string.Concat("Total".PadRight(ReceiptWidth - totalEntry.Length), totalEntry));
        }


        /// <summary>
        /// The width of the receipt
        /// </summary>
        private const int ReceiptWidth = 50;
    }
}