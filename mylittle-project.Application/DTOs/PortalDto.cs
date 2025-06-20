using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PortalDto.cs
namespace mylittle_project.Application.DTOs
{
    public class PortalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastAccessed { get; set; }
    }
}

