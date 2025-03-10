// See https://aka.ms/new-console-template for more information
using OpenClosed;

Console.WriteLine("Hello, World!");
/*
 *  Bir nesne .....gelişime...... açık .....değişime... kapalı olmalıdır.
 *  
 *  
 */

Customer customer = new Customer { Name = "Ali", Card = new PlatinumCard() };
OrderManager orderManager = new OrderManager { Customer = customer };
decimal discountedPrice = orderManager.GetDiscountedPrice(1000);
Console.WriteLine(discountedPrice);