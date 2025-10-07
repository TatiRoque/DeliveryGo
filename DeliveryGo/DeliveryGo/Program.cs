using System;
using DeliveryGo.Application.Facade;
using DeliveryGo.Core.Shared.Entities;

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
                ShowMenu();
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
                        Console.WriteLine("\nItem added to cart successfully!");
                        break;

                    case "2":
                        Console.Clear();
                        facade.RemoveItemFromCart(PromptString("SKU to remove: "));
                        Console.WriteLine("\nItem removed from cart successfully!");
                        break;

                    case "3":
                        Console.Clear();
                        string skuUpdate = PromptString("SKU to update: ");
                        int newQty = PromptInt("New quantity: ");
                        facade.UpdateItemQuantity(skuUpdate, newQty);
                        Console.WriteLine("\nItem quantity updated successfully!");
                        break;

                    case "4":
                        Console.Clear();
                        ShowCart(facade);
                        break;

                    case "5":
                        Console.Clear();
                        var order = facade.CreateOrder();
                        Console.WriteLine($"\nOrder created with ID: {order.Id}");
                        break;

                    case "6":
                        Console.Clear();
                        string shippingType = PromptString("Shipping type (moto/mail/store): ");
                        facade.SetShippingStrategy(shippingType);
                        Console.WriteLine($"\nShipping method set to: {shippingType}");
                        break;

                    case "7":
                        Console.Clear();
                        string payType = PromptString("Payment type (credit/bank/mp): ");
                        facade.SetPayment(payType);
                        facade.Pay();

                        Console.WriteLine("\nPayment successful!");
                        Console.WriteLine($"Order ID: {facade.CreateOrder().Id}");
                        Console.WriteLine("Your cart has been cleared.");
                        Console.WriteLine("────────────────────────────────────────────");
                        Console.WriteLine("Thank you for choosing DELIVERYGO");
                        break;

                    case "8":
                        Console.Clear();
                        running = false;
                        Console.WriteLine("Exiting DeliveryGo System... Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║          DELIVERYGO CHECKOUT         ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ [1]  Add item to cart                ║");
            Console.WriteLine("║ [2]  Remove item from cart           ║");
            Console.WriteLine("║ [3]  Update item quantity            ║");
            Console.WriteLine("║ [4]  View cart                       ║");
            Console.WriteLine("║ [5]  Create order                    ║");
            Console.WriteLine("║ [6]  Set shipping method             ║");
            Console.WriteLine("║ [7]  Pay and checkout                ║");
            Console.WriteLine("║ [8]  Exit                            ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ Tip: Complete your order before      ║");
            Console.WriteLine("║      exiting the program!            ║");
            Console.WriteLine("╚══════════════════════════════════════╝\n");
        }

        static void ShowCart(CheckoutFacade facade)
        {
            Console.WriteLine("YOUR CART");
            Console.WriteLine("────────────────────────────────────────────");
            Console.WriteLine("SKU        NAME           QTY   PRICE   TOTAL");
            Console.WriteLine("────────────────────────────────────────────");

            decimal total = 0;
            foreach (var item in facade.GetCartItems())
            {
                decimal lineTotal = item.Price * item.Quantity;
                total += lineTotal;
                Console.WriteLine($"{item.Sku,-10}{item.Name,-15}{item.Quantity,-6}{item.Price,-8:C}{lineTotal,8:C}");
            }

            Console.WriteLine("────────────────────────────────────────────");
            Console.WriteLine($"TOTAL:{total,33:C}");
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
