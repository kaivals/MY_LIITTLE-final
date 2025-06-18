using Microsoft.AspNetCore.Mvc;
using mylittle_project.Application.DTOs;
using mylittle_project.Application.Interfaces;

namespace mylittle_project.Controllers
{
    [ApiController]
    [Route("api/SubscriptionDealer")]
    public class SubscriptionDealerController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionDealerController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        // POST: api/subscription
        [HttpPost]
        public async Task<IActionResult> AssignSubscription([FromBody] SubscriptionDealerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _subscriptionService.AssignSubscriptionAsync(dto);
            return Ok(new { Message = "Subscription assigned successfully", SubscriptionId = id });
        }

    }
}
