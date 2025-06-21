using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mylittle_project.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string Category { get; set; }

        public string Brand { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        [ForeignKey("Tenant")]
        public Guid TenantId { get; set; }

        public Tenant Tenant { get; set; }
    }
}
