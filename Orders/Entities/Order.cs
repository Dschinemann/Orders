using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Enums;
using Orders.Entities;
using System.Globalization;

namespace Orders.Entities
{
    public class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public Cliente Cliente { get; set; }

        public Order(DateTime dateTime, OrderStatus status, Cliente cliente)
        {
            Moment = dateTime;
            Status = status;
            Cliente = cliente;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            if (OrderItems.Contains(item))
            {
                OrderItems.Remove(item);
            }
        }
        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in OrderItems)
            {
                 sum += item.Subtotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            double total = Total();
            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString());
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.AppendLine(Cliente.ToString());
            sb.AppendLine("Order items: ");
            foreach(OrderItem item in OrderItems)
            {
                sb.AppendLine(item.ToString());
            }
            sb.Append("Total Price  ");
            sb.Append(total.ToString("C2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
