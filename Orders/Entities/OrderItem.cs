using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Entities
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double Subtotal()
        {
            return this.Quantity * this.Price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Product.Name);
            sb.Append(" ");
            sb.Append(Price.ToString("C2", CultureInfo.InvariantCulture));
            sb.Append(" ");
            sb.Append("Quantity: ");
            sb.Append(Quantity.ToString());
            sb.Append(" ");
            sb.Append("Subtotal: ");
            sb.Append(Subtotal().ToString("C2", CultureInfo.InvariantCulture));
            return sb.ToString();

        }
    }
}
