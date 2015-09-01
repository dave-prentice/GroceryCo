using System.Collections.Generic;
using GroceryCo.Checkout.Model;

namespace GroceryCo.Checkout.Views
{
    public interface IReceiptView
    {
        /// <summary>
        /// The sequence of <see cref="ReceiptEntries"/> which will be rendered
        /// </summary>
        IEnumerable<ReceiptEntry> ReceiptEntries { get; }


        /// <summary>
        /// Renders a collection of <see cref="ReceiptEntry"/> objects to the console
        /// </summary>
        void Render();
    }
}
