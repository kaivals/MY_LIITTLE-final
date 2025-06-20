using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mylittle_project.Application.DTOs
{
    public class TenentPortalLinkDto
    {
        public int Id { get; set; }
        public int SourcePortalId { get; set; }
        public int TargetPortalId { get; set; }
        public string LinkType { get; set; }
        public DateTime LinkedSince { get; set; }
    }
}

