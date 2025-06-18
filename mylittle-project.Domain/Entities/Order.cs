using System;
using System.Collections.Generic;

namespace mylittle_project.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }

        public string Portal { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string ShippingStatus { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public string Comments { get; set; }

        // ✅ Correct EF relationship
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
