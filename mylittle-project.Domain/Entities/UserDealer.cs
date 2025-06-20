﻿using mylittle_project.Domain.Entities.mylittle_project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class UserDealer
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = "Dealer";
        public bool IsActive { get; set; }

        // Foreign Key
        public Guid BusinessInfoId { get; set; }
        public BusinessInfo BusinessInfo { get; set; } = null!;
        public ICollection<BusinessInfo>? Businesses { get; set; }
     
        public ICollection<PortalAssignment> PortalAssignments { get; set; } = new List<PortalAssignment>();
    }
}