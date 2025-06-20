using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs
{
    public class UserDealerDto
    {
        public Guid BusinessInfoId { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Role { get; set; } = "Dealer";
        public bool IsActive { get; set; }
        public List<PortalAssignmentDto> PortalAssignments { get; set; } = new();
    }

    public class PortalAssignmentDto
    {
        public string PortalName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
