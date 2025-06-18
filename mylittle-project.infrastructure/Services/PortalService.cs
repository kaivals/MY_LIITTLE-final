using Microsoft.EntityFrameworkCore;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using mylittle_project.Domain.Entities;
using mylittle_project.infrastructure.Data;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylittle_project.Infrastructure.Services
{
    public class PortalService : IPortalService
    {
        private readonly AppDbContext _context;

        public PortalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Portal>> GetAllPortalsAsync()
        {
            return await _context.Portals.ToListAsync();
        }

        public async Task<IEnumerable<Feature>> GetFeaturesByPortalIdAsync(int portalId)
        {
            return await _context.PortalFeatures
                .Where(pf => pf.PortalId == portalId)
                .Include(pf => pf.Feature)
                .Select(pf => new Feature
                {
                    Id = pf.Feature.Id,
                    Name = pf.Feature.Name,
                    Category = pf.Feature.Category,
                    IsPremium = pf.Feature.IsPremium,
                    IsEnabled = pf.IsEnabled
                })
                .ToListAsync();
        }

        public async Task ToggleFeatureAsync(int portalId, int featureId, bool isEnabled)
        {
            var portalFeature = await _context.PortalFeatures
                .FirstOrDefaultAsync(pf => pf.PortalId == portalId && pf.FeatureId == featureId);

            if (portalFeature != null)
            {
                portalFeature.IsEnabled = isEnabled;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ToggleAllFeaturesAsync(int portalId, bool isEnabled)
        {
            var features = await _context.PortalFeatures
                .Where(pf => pf.PortalId == portalId)
                .ToListAsync();

            foreach (var feature in features)
            {
                feature.IsEnabled = isEnabled;
            }

            await _context.SaveChangesAsync();
        }

        public Task ToggleFeatureAccessAsync(UpdateFeatureAccessDto dto)
        {
            throw new NotImplementedException();
        }

        public Task ToggleAllFeatureAccessAsync(UpdateAllFeatureAccessDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
