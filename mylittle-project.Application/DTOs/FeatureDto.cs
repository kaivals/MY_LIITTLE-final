using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// FeatureDto.cs
namespace mylittle_project.Application.DTOs
{
    public class FeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsPremium { get; set; }
    }
}

