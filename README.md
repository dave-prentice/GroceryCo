#GroceryCo Grocery Store Checkout Sample

This sample application simulates a grocery store checkout.

By convention the checkout sample application attempts to load three JSON files on startup:

GroceryItems.json - a list of all items in stock at the shop.

Example:
```json
[{"id": "Apple", "price": 0.50}, {"id": "Orange", "price": 1.0}]
```

Basket.json - the contents of a customer's basket.
Example:
```json
[
  { "id": "Apple" },
  { "id": "Apple" },
  { "id": "Apple" },
  { "id": "Apple" },
  { "id": "Apple" },
  { "id": "Orange" },
  { "id": "Orange" },
  { "id": "Orange" }
]
```

and

Promotions.json - The current promotions on offer at the store.

Example:
```json
[
  {
    "itemId": "Apple",
    "quantity": 2,
    "rate": 0.5,
    "promotionType": "relative"
  }
]
```

There are two poiisble types of promotions:
- `relative` - where the offer price is relative to the original item price for example 'buy one get one free'  as shown in the example above. The relative price if bought in multiples of 2 is 0.5 (50%)
- `fixed` - where the cost of multiple items is fixed. An example would be 'buy 2 for $3' and the JSON representation would be:
```json
[
  {
    "itemId": "Apple",
    "quantity": 2,
    "rate": 3.0,
    "promotionType": "fixed"
  }
]
```

Run `GroceryCo.Console.exe` (found in the build output directory) from the command line to execute. 

Unit tests can be run by executing
```
.\packages\NUnit.Runners.2.6.4\tools\nunit.exe .\src\GroceryCo.Checkout.Tests\bin\Debug\GroceryCo.Checkout.Tests.dll
```

from the comand line in the solution directory.
