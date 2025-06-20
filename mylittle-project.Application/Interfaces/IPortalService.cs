using mylittle_project.Application.DTOs;
using mylittle_project.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mylittle_project.Application.Interfaces
{
    public interface IPortalService
    {
        Task<IEnumerable<Portal>> GetAllPortalsAsync();
        Task<IEnumerable<FeatureDto>> GetFeaturesByPortalIdAsync(int portalId);
        Task ToggleFeatureAccessAsync(UpdateFeatureAccessDto dto);
        Task ToggleAllFeatureAccessAsync(UpdateAllFeatureAccessDto dto);
    }

}
