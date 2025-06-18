using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string BuyerName { get; set; }
        public string Portal { get; set; }
        public string Dealer { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }

}
