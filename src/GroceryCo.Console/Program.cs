using System.IO;
using System.Linq;
using GroceryCo.Checkout.Controllers;
using GroceryCo.Checkout.Loaders;

namespace GroceryCo.Console
{
    public static class Program
    {
        public static void Main()
        {
            // Load all data required to run the program
            var priceList = GroceryItemLoader.Load(File.ReadAllText(".\\GroceryItems.json"))
                .ToDictionary(i => i.Id, i => i);

            var promotions = PromotionLoader.Load(File.ReadAllText(".\\Promotions.json"), priceList);

            var basket = BasketItemLoader.Load(File.ReadAllText(".\\Basket.json"));

            //Instantiate the controller and execute the checkout
            var controller = new CheckoutController(priceList, promotions);
            controller.Checkout(basket);

            System.Console.WriteLine("Press a key to continue");
            System.Console.ReadKey();
        }
    }
}
