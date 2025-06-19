using mylittle_project.Application.DTOs;
using mylittle_project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.Interfaces
{
    public interface IUserDealerService
    {
        Task<Guid> AddUserAsync(UserDealerDto dto);
        Task<List<UserDealerDto>> GetAllUsersAsync();
        Task<List<UserDealerDto>> GetUsersByDealerAsync(Guid dealerId);
    }
}
