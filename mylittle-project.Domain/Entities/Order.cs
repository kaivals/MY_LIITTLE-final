using System;
using System.Collections.Generic;

namespace mylittle_project.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } 

        public Guid DealerId { get; set; }
        public UserDealer? Dealer { get; set; }

        public string Portal { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public string ShippingStatus { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public string Comments { get; set; } = string.Empty;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
