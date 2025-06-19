using Microsoft.AspNetCore.Mvc;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;

namespace mylittle_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDealerController : ControllerBase
    {
        private readonly IUserDealerService _service;

        public UserDealerController(IUserDealerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDealerDto dto)
        {
            var userId = await _service.AddUserAsync(dto);
            return Ok(new { UserId = userId });
        }

        // ✅ Changed "dealerId" to "businessInfoId" and Guid → int
        [HttpGet("{businessInfoId}")]
        public async Task<IActionResult> GetUsers(Guid businessInfoId)
        {
            var users = await _service.GetUsersByDealerAsync(businessInfoId);
            return Ok(users);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
