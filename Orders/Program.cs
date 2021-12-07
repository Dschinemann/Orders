using Orders.Entities;
using Orders.Enums;
using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Cliente data");
        Console.Write("Name:");
        string name = Console.ReadLine();
        Console.Write("Email:");
        string email = Console.ReadLine();
        Console.Write("Birth date (DD/MM/YYYY):");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());

        Cliente Cliente = new Cliente(name, email, birthDate);

        Console.WriteLine("Enter order data");
        Console.Write("Status:");
        OrderStatus OrderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());
        Console.Write("How many items to this order? :");
        int quantityOrder = int.Parse(Console.ReadLine());
        DateTime date = DateTime.Now;
        Order Order = new Order(date, OrderStatus, Cliente);


        for (int i = 0; i < quantityOrder; i++)
        {
            Console.WriteLine($"Enter #{i} item data: ");
            Console.Write("Product Name:");
            string ProductName = Console.ReadLine();
            Console.Write("Product price:");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Product product = new Product(ProductName, price);
            OrderItem orderItem = new OrderItem(quantity, price, product);
            Order.AddItem(orderItem);            
        }
        Console.WriteLine("ORDER SUMARY");
        Console.WriteLine(Order);

    }

}
