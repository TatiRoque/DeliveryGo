using DeliveryGo.Application.Services.Implementations;
using DeliveryGo.Application.Strategy.ShippingStrategies;
using DeliveryGo.Core.Command.Commands;
using DeliveryGo.Core.Command.Invokers;
using DeliveryGo.Core.Payment.Adapters;
using DeliveryGo.Core.Payment.Decorators;
using DeliveryGo.Core.Payment.Factories;
using DeliveryGo.Core.Shared.Contracts;
using DeliveryGo.Core.Shared.Entities;
using System;
using System.Collections.Generic;

namespace DeliveryGo.Application.Facade
{
    public class CheckoutFacade
    {
        private readonly Cart _cart;
        private readonly CartEditor _cartEditor;
        private readonly OrderService _orderService;
        private IPayment _payment;
        private IShippingStrategy _shippingStrategy;


        public CheckoutFacade()
        {
            _cart = new Cart();
            _cartEditor = new CartEditor(_cart);
            _orderService = new OrderService();
        }

        // CART OPERATIONS
        public void AddItemToCart(string sku, string name, decimal price, int quantity)
        {
            var command = new AddItemCommand(_cart, sku, name, price, quantity);
            _cartEditor.ExecuteCommand(command);
        }

        public void RemoveItemFromCart(string sku)
        {
            var command = new RemoveItemCommand(sku);
            _cartEditor.ExecuteCommand(command);
        }

        public void UpdateItemQuantity(string sku, int quantity)
        {
            var command = new SetQuantityCommand(sku, quantity);
            _cartEditor.ExecuteCommand(command);
        }

        public IReadOnlyCollection<Item> GetCartItems() => _cart.Items;

        // ORDER OPERATIONS
        public DeliveryGo.Core.Shared.Entities.Order CreateOrder()
        {
            var order = _orderService.CreateOrder(_cart);
            return order;
        }

        public void SubscribeObserver(IObserver observer)
        {
            _orderService.Subscribe(observer);
        }

        public void UnsubscribeObserver(IObserver observer)
        {
            _orderService.Unsubscribe(observer);
        }

        // PAYMENT OPERATIONS
        public void SetPayment(string paymentType, bool applyTax = false, bool applyCoupon = false)
        {
            _payment = PaymentFactory.Create(paymentType);

            if (applyTax)
                _payment = new TaxDecorator(_payment);
        }

        public void Pay()
        {
            if (_payment == null)
                throw new InvalidOperationException("Payment method is not set.");

            bool success = _payment.ProcessPayment(_cart.GetTotal());

            if (success)
            {
                _cart.Clear(); // Limpia el carrito después del pago exitoso
            }
            else
            {
                Console.WriteLine("Payment failed. Please try again.");
            }
        }

        // SHIPPING OPERATIONS
        public void SetShippingStrategy(string shippingType)
        {
            _shippingStrategy = shippingType.ToLower() switch
            {
                "moto" => new MotorcycleShipping(),
                "mail" => new MailShipping(),
                "store" => new StorePickup(),
                _ => throw new ArgumentException("Invalid shipping type")
            };
        }

        public void ShipOrder(DeliveryGo.Core.Shared.Entities.Order order)
        {
            if (_shippingStrategy == null)
                throw new InvalidOperationException("Shipping strategy is not set.");
            _shippingStrategy.Ship(order);
        }
    }
}
