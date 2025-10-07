# 🚀 DeliveryGo - E-commerce System with Design Patterns

**Tecnicatura Superior en Desarrollo de Software - Programación II**

Checkout system for e-commerce implemented in C# .NET demonstrating the practical application of multiple design patterns.

---

## 📖 Description

DeliveryGo is a console application that simulates a checkout system for an e-commerce platform. The project implements **9 different design patterns** organized into three categories:

- **Creational Patterns**: Singleton, Factory, Builder
- **Structural Patterns**: Adapter, Decorator, Facade
- **Behavioral Patterns**: Command, Strategy, Observer

### Main Features:

✅ Cart management with Undo/Redo  
✅ Multiple interchangeable shipping strategies  
✅ Payment system with decorators (VAT, coupons)  
✅ Step-by-step order building  
✅ Real-time notifications via observers  
✅ Unified interface using Facade  

---

## 🎯 Implemented Patterns

### Creational Patterns

| Pattern | Location | Purpose |
|--------|-----------|-----------|
| **Singleton** | `ConfigManager.cs` | Single configuration for the application (VAT, free shipping threshold) |
| **Factory** | `PaymentFactory.cs` | Creation of different payment methods |
| **Builder** | `OrderBuilder.cs` | Step-by-step construction of orders |

### Structural Patterns

| Pattern | Location | Purpose |
|--------|-----------|-----------|
| **Adapter** | `MpPaymentAdapter.cs` | Integration with external MercadoPago SDK |
| **Decorator** | `TaxDecorator.cs` | Dynamically add VAT and coupons to payments |
| **Facade** | `CheckoutFacade.cs` | Simplify complex system operations |

### Behavioral Patterns

| Pattern | Location | Purpose |
|--------|-----------|-----------|
| **Command** | `AddItemCommand.cs`, `RemoveItemCommand.cs`, `SetQuantityCommand.cs` | Encapsulate cart actions with Undo/Redo |
| **Strategy** | `MotorcycleShipping.cs`, `MailShipping.cs`, `StorePickup.cs` | Swap shipping calculation algorithms |
| **Observer** | `CustomerObserver.cs`, `LogisticsObserver.cs`, `AuditObserver.cs` | Notify order status changes |


---

## 📁 Project Structure

```
DeliveryGo/
├── Application/
│   ├── Facade/
│   │   └── CheckoutFacade.cs          # ⭐ Facade Pattern
│   ├── Order/
│   │   ├── Builders/
│   │   │   └── OrderBuilder.cs        # ⭐ Builder Pattern
│   │   └── Observers/
│   │       ├── CustomerObserver.cs    # ⭐ Observer Pattern
│   │       ├── LogisticsObserver.cs
│   │       └── AuditObserver.cs
│   ├── Services/
│   │   └── Implementations/
│   │       ├── OrderChangeEventArgs.cs
│   │       ├── OrderService.cs        # Order management + Observer Subject
│   │       └── ShippingService.cs     
│   └── Strategy/
│       └── ShippingStrategies/
│           ├── MotorcycleShipping.cs  # ⭐ Strategy Pattern
│           ├── MailShipping.cs
│           └── StorePickup.cs
├── Core/
│   ├── Command/
│   │   ├── Commands/
│   │   │   ├── AddItemCommand.cs      # ⭐ Command Pattern
│   │   │   ├── RemoveItemCommand.cs
│   │   │   └── SetQuantityCommand.cs
│   │   └── Invokers/
│   │       └── CartEditor.cs
│   ├── Config/
│   │   └── ConfigManager.cs           # ⭐ Singleton Pattern
│   ├── Payment/
│   │   ├── Adapters/
│   │   │   ├── FakeMpSdk.cs
│   │   │   └── MpPaymentAdapter.cs    # ⭐ Adapter Pattern
│   │   ├── Decorators/
│   │   │   ├── TaxDecorator.cs        # ⭐ Decorator Pattern 
│   │   ├── Factories/
│   │   │   └── PaymentFactory.cs      # ⭐ Factory Pattern
│   │   └── Implementations/
│   │       ├── CardPayment.cs
│   │       ├── BankTransferPayment.cs
│   │       └── MpPayment.cs
│   └── Shared/
│       ├── Contracts/                  # Interfaces
│       ├── Entities/                   # Cart, Order, Item
│       └── Enums/                      # OrderStatus, PaymentType, etc.
└── Program.cs                          # Entry point

```

---

## 🛠️ Requirements

- **.NET 6.0** or higher
- Recommended IDE: **Visual Studio 2022** or **Visual Studio Code** with C# extension

---

## 🚀 Installation and Usage

### 1. Clone the repository

```bash
git clone https://github.com/tu-usuario/DeliveryGo.git
cd DeliveryGo
```

### 2. Build the project

```bash
dotnet build
```

### 3. Run the program

```bash
dotnet run
```

## 👥 Task Division

### Tatiana Roque
- ✅ Implementation of `Cart` and `Item`
- ✅ Invoker: `CartEditor` with Undo/Redo history
- ✅ Interface `ICartPort`
- ✅ Builder: OrderBuilder
- ✅ Observers: CustomerObserver, LogisticsObserver, AuditObserver
- ✅ Facade: CheckoutFacade (full integration)
- ✅ Decorators

### Ariel Soria
- ✅ Shipping strategies: `MotorcycleShipping`, `MailShipping`, `StorePickup`
- ✅ Implementation of `ShippingService`
- ✅ Commands: `AddItemCommand`, `RemoveItemCommand`, `SetQuantityCommand`
- ✅ Factory: PaymentFactory
- ✅ Adapter: MpPaymentAdapter with FakeMpSdk

### Full Team
- ✅ `Program.cs` - Interactive menu 

---

## 🏗️ Architecture

### Operation Flow

```
User
   ↓
CheckoutFacade (Facade Pattern)
   ↓
┌─────────────┬──────────────┬─────────────────┐
│   Cart      │   Shipping   │      Payment    │
│  (Command)  │  (Strategy)  │ (Factory/Dec)   │
└─────────────┴──────────────┴─────────────────┘
   ↓
OrderBuilder (Builder Pattern)
   ↓
OrderService (Observer Subject)
   ↓
Observers (Customer, Logistics, Audit)

```

### Applied SOLID Principles

- **Single Responsibility**: Each class has a single responsibility
- **Open/Closed**: Extensible through strategies, decorators, and commands
- **Liskov Substitution**: All implementations are interchangeable
- **Interface Segregation**: Specific and cohesive interfaces
- **Dependency Inversion**: Dependencies rely on abstractions (interfaces)

---

## 📊 UML Diagram

https://www.mermaidchart.com/d/2fd6da39-b00e-4b79-a924-828fa7225361

---

## 🚀 Future Implementation

🔧 Fix Order calls to use the object directly, allowing a cleaner approach and avoiding the need for full path references.

💳 Implement `CouponDecorator.cs` to dynamically apply discounts to payments, ensuring flexible and modular pricing adjustments.

---

## 🎓 Team Members

- **Tatiana Roque**
- **Ariel Soria**

Tecnicatura Superior en Software  
Programación II  
2025

---

## 📄 License GPL-3.0

This project is for educational purposes for the Tecnicatura Superior en Software.
