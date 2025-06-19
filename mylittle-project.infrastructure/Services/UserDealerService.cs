using Microsoft.EntityFrameworkCore;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;
using mylittle_project.Domain.Entities;
using mylittle_project.infrastructure.Data;

public class UserDealerService : IUserDealerService
{
    private readonly AppDbContext _context;

    public UserDealerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddUserAsync(UserDealerDto dto)
    {
        var user = new UserDealer
        {
            BusinessInfoId = dto.BusinessInfoId,  // Link dealer
            Username = dto.Username,
            Role = dto.Role,
            IsActive = dto.IsActive,
            PortalAssignments = dto.PortalAssignments.Select(pa => new PortalAssignment
            {
                PortalName = pa.PortalName,
                Category = pa.Category
            }).ToList()
        };

        _context.UserDealers.Add(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<List<UserDealerDto>> GetAllUsersAsync()
    {
        return await _context.UserDealers
            .Include(u => u.PortalAssignments)
            .Select(u => new UserDealerDto
            {
                BusinessInfoId = u.BusinessInfoId,
                Username = u.Username,
                Role = u.Role,
                IsActive = u.IsActive,
                PortalAssignments = u.PortalAssignments.Select(pa => new PortalAssignmentDto
                {
                    PortalName = pa.PortalName,
                    Category = pa.Category
                }).ToList()
            }).ToListAsync();
    }
    public async Task<List<UserDealerDto>> GetUsersByDealerAsync(Guid dealerId)
    {
        return await _context.UserDealers
            .Include(u => u.PortalAssignments)
            .Where(u => u.BusinessInfoId == dealerId)
            .Select(u => new UserDealerDto
            {
                BusinessInfoId = u.BusinessInfoId,
                Username = u.Username,
                Role = u.Role,
                IsActive = u.IsActive,
                PortalAssignments = u.PortalAssignments.Select(pa => new PortalAssignmentDto
                {
                    PortalName = pa.PortalName,
                    Category = pa.Category
                }).ToList()
            }).ToListAsync();
    }
}

