using Microsoft.EntityFrameworkCore;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using mylittle_project.Domain.Entities;
using mylittle_project.infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylittle_project.infrastructure.Services
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

        public async Task<IEnumerable<FeatureDto>> GetFeaturesByPortalIdAsync(int portalId)
        {
            // Join PortalFeatures with Features based on FeatureId
            var features = await _context.PortalFeatures
                .Where(pf => pf.PortalId == portalId)
                .Join(_context.Features,
                      pf => pf.FeatureId,
                      f => f.Id,
                      (pf, f) => new FeatureDto
                      {
                          Id = f.Id,
                          Name = f.Name,
                          Category = f.Category,
                          IsPremium = f.IsPremium,
                          IsEnabled = pf.IsEnabled
                      })
                .ToListAsync();

            return features;
        }


        public async Task ToggleFeatureAccessAsync(UpdateFeatureAccessDto dto)
        {
            // Check if Feature exists
            var featureExists = await _context.Features.AnyAsync(f => f.Id == dto.FeatureId);
            if (!featureExists)
                throw new KeyNotFoundException($"FeatureId {dto.FeatureId} does not exist.");

            // Check if Portal exists
            var portalExists = await _context.Portals.AnyAsync(p => p.Id == dto.PortalId);
            if (!portalExists)
                throw new KeyNotFoundException($"PortalId {dto.PortalId} does not exist.");

            // Toggle or Add
            var portalFeature = await _context.PortalFeatures
                .FirstOrDefaultAsync(pf => pf.PortalId == dto.PortalId && pf.FeatureId == dto.FeatureId);

            if (portalFeature != null)
            {
                portalFeature.IsEnabled = dto.IsEnabled;
            }
            else
            {
                _context.PortalFeatures.Add(new PortalFeature
                {
                    PortalId = dto.PortalId,
                    FeatureId = dto.FeatureId,
                    IsEnabled = dto.IsEnabled
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task ToggleAllFeatureAccessAsync(UpdateAllFeatureAccessDto dto)
        {
            // Validate Portal existence
            var portalExists = await _context.Portals.AnyAsync(p => p.Id == dto.PortalId);
            if (!portalExists)
                throw new KeyNotFoundException($"PortalId {dto.PortalId} does not exist.");

            // Validate Features
            var validFeatureIds = await _context.Features.Select(f => f.Id).ToListAsync();
            var invalidFeatureIds = dto.FeatureIds.Except(validFeatureIds).ToList();
            if (invalidFeatureIds.Any())
                throw new ArgumentException("Invalid FeatureIds: " + string.Join(", ", invalidFeatureIds));

            // Get existing portal-feature mappings
            var existing = await _context.PortalFeatures
                .Where(pf => pf.PortalId == dto.PortalId)
                .ToListAsync();

            var existingMap = existing.ToDictionary(pf => pf.FeatureId);

            foreach (var featureId in dto.FeatureIds)
            {
                if (existingMap.TryGetValue(featureId, out var portalFeature))
                {
                    portalFeature.IsEnabled = dto.IsEnabled;
                }
                else
                {
                    _context.PortalFeatures.Add(new PortalFeature
                    {
                        PortalId = dto.PortalId,
                        FeatureId = featureId,
                        IsEnabled = dto.IsEnabled
                    });
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
