﻿using System;
using System.Collections.Generic;
using System.Linq;
using GroceryCo.Checkout.Model;

namespace GroceryCo.Checkout.Views
{
    /// <summary>
    /// A view which renders a collection or <see cref="ReceiptEntry"/> objects to the console
    /// </summary>
    internal sealed class ConsoleReceiptView : IReceiptView
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="receiptEntries">The <see cref="ReceiptEntry"/> objects to be rendered in the view</param>
        public ConsoleReceiptView(IEnumerable<ReceiptEntry> receiptEntries)
        {
            if (receiptEntries == null) { throw new ArgumentNullException(nameof(receiptEntries));}

            ReceiptEntries = receiptEntries;
        }


        /// <summary>
        /// The sequence of <see cref="ReceiptEntries"/> which will be rendered
        /// </summary>
        public IEnumerable<ReceiptEntry> ReceiptEntries { get; }


        /// <summary>
        /// Renders a collection of <see cref="ReceiptEntry"/> objects to the console
        /// </summary>
        public void Render()
        {
            var enumeratedEntries = ReceiptEntries as ReceiptEntry[] ?? ReceiptEntries.ToArray();

            // Compute the total amount of the receipt
            var receiptTotal = GetReceiptTotal(enumeratedEntries);

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
        /// Computes the receipt toal for a given sequence of <see cref="ReceiptEntry"/> objects
        /// </summary>
        /// <param name="receiptEntries">The <see cref="ReceiptEntry"/> objects for which the total is being calculated</param>
        /// <returns>The receipt total</returns>
        internal static decimal GetReceiptTotal(IEnumerable<ReceiptEntry> receiptEntries)
        {
            return receiptEntries.Sum(e => e.TotalPrice);
        }


        /// <summary>
        /// The width of the receipt
        /// </summary>
        private const int ReceiptWidth = 50;
    }
}
