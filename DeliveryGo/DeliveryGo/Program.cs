using DeliveryGo.Application.Facade;
using DeliveryGo.Core.Shared.Entities;
using System;

namespace DeliveryGo
{
    class Program
    {
        static void Main()
        {
            var facade = new CheckoutFacade();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- DeliveryGo Menu ---");
                Console.WriteLine("1. Add item to cart");
                Console.WriteLine("2. Remove item from cart");
                Console.WriteLine("3. Update item quantity");
                Console.WriteLine("4. View cart");
                Console.WriteLine("5. Create order");
                Console.WriteLine("6. Set shipping method");
                Console.WriteLine("7. Pay");
                Console.WriteLine("8. Exit");

                string option = PromptString("Select an option: ");

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        string sku = PromptString("SKU: ");
                        string name = PromptString("Name: ");
                        decimal price = PromptDecimal("Price: ");
                        int quantity = PromptInt("Quantity: ");
                        facade.AddItemToCart(sku, name, price, quantity);
                        break;

                    case "2":
                        Console.Clear();
                        facade.RemoveItemFromCart(PromptString("SKU to remove: "));
                        break;

                    case "3":
                        Console.Clear();
                        string skuUpdate = PromptString("SKU to update: ");
                        int newQty = PromptInt("New quantity: ");
                        facade.UpdateItemQuantity(skuUpdate, newQty);
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("--- Cart Items ---");
                        foreach (var item in facade.GetCartItems())
                            Console.WriteLine($"{item.Sku} - {item.Name} - {item.Quantity} x {item.Price:C} = {item.GetTotal():C}");
                        break;

                    case "5":
                        Console.Clear();
                        var order = facade.CreateOrder();
                        Console.WriteLine($"Order created with ID: {order.Id}");
                        break;

                    case "6":
                        Console.Clear();
                        string shippingType = PromptString("Shipping type (moto/mail/store): ");
                        facade.SetShippingStrategy(shippingType);
                        break;

                    case "7":
                        Console.Clear();
                        string payType = PromptString("Payment type (credit/bank/mp): ");
                        facade.SetPayment(payType);
                        facade.Pay();
                        Console.WriteLine("Payment successful! Cart cleared.");
                        break;

                    case "8":
                        Console.Clear();
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static string PromptString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        static int PromptInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.WriteLine("Invalid number. Try again.");
            }
        }

        static decimal PromptDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                    return value;
                Console.WriteLine("Invalid decimal. Try again.");
            }
        }
    }
}
