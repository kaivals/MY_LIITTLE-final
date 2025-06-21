using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class BusinessInfo
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }              // ← Portal to which this business belongs
        public Tenant Tenant { get; set; } = null!;
        public Guid UserDealerId { get; set; }
        public string DealerName { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string BusinessNumber { get; set; } = string.Empty;
        public string BusinessEmail { get; set; } = string.Empty;
        public string BusinessAddress { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Timezone { get; set; } = string.Empty;
        public UserDealer? UserDealer { get; set; } // match class name

    }
}