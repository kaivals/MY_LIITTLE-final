using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// UpdateAllFeatureAccessDto.cs
namespace mylittle_project.Application.DTOs
{
    public class UpdateAllFeatureAccessDto
    {
        public int PortalId { get; set; }
        public bool IsEnabled { get; set; }
    }
}
