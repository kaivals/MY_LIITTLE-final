using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs
{
    public class ActivityLogDto
    {
        public int Id { get; set; }                     // Unique ID for the log entry
        public int TenantId { get; set; }               // To associate activity with a tenant
        public string PerformedBy { get; set; }         // User who performed the action (e.g., admin)
        public string Action { get; set; }              // Description of the action (e.g., "Created Tenant", "Updated Settings")
        public DateTime Timestamp { get; set; }         // When the action occurred
        public string Details { get; set; }             // Optional: JSON or text with additional context
    }

}
