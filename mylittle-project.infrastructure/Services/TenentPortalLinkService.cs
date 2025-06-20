using Microsoft.EntityFrameworkCore;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using mylittle_project.Domain.Entities;
using mylittle_project.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylittle_project.infrastructure.Services
{
    public class TenentPortalLinkService : ITenentPortalLinkService
    {
        private readonly AppDbContext _context;

        public TenentPortalLinkService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddLinkAsync(TenentPortalLinkDto dto)
        {
            var link = new TenentPortalLink
            {
                SourcePortalId = dto.SourcePortalId,
                TargetPortalId = dto.TargetPortalId,
                LinkType = dto.LinkType,
                LinkedSince = dto.LinkedSince == default ? DateTime.UtcNow : dto.LinkedSince
            };

            _context.TenentPortalLinks.Add(link);
            await _context.SaveChangesAsync();
        }

        public async Task AddLinksBatchAsync(TenentPortalLinkBatchDto dto)
        {
            var existingPortalIds = await _context.Portals
                .Where(p => dto.TargetPortalIds.Contains(p.Id))
                .Select(p => p.Id)
                .ToListAsync();

            var validTargetIds = dto.TargetPortalIds
                .Distinct()
                .Where(id => id != dto.SourcePortalId && existingPortalIds.Contains(id))
                .ToList();

            if (!validTargetIds.Any())
                throw new Exception("No valid TargetPortalIds found in Portals table.");

            var now = DateTime.UtcNow;
            var links = validTargetIds.Select(targetId => new TenentPortalLink
            {
                SourcePortalId = dto.SourcePortalId,
                TargetPortalId = targetId,
                LinkType = dto.LinkType,
                LinkedSince = now
            }).ToList();

            _context.TenentPortalLinks.AddRange(links);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<TenentPortalLinkViewDto>> GetAllLinkedPortalsAsync()
        {
            return await _context.TenentPortalLinks
                .Include(l => l.SourcePortal)
                .Include(l => l.TargetPortal)
                .Select(l => new TenentPortalLinkViewDto
                {
                    SourcePortalId = l.SourcePortalId,
                    SourcePortalName = l.SourcePortal.Name,
                    TargetPortalId = l.TargetPortalId,
                    TargetPortalName = l.TargetPortal.Name,
                    LinkType = l.LinkType,
                    LinkedSince = l.LinkedSince
                })
                .ToListAsync();
        }
    }
}
