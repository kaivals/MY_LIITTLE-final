using mylittle_project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mylittle_project.Application.DTOs;

namespace mylittle_project.Application.Interfaces
{
    public interface IPortalService
    {
        Task<IEnumerable<Portal>> GetAllPortalsAsync();
        Task<IEnumerable<Feature>> GetFeaturesByPortalIdAsync(int portalId);
        Task ToggleFeatureAccessAsync(UpdateFeatureAccessDto dto);
        Task ToggleAllFeatureAccessAsync(UpdateAllFeatureAccessDto dto);
    }
}

