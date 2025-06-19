using mylittle_project.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITenentPortalLinkService
{
    Task AddLinkAsync(TenentPortalLinkDto dto); // single
    Task AddLinksBatchAsync(TenentPortalLinkBatchDto dto); // multiple
    Task<IEnumerable<TenentPortalLinkViewDto>> GetAllLinkedPortalsAsync(); // view all links
}
