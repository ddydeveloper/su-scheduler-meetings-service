using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsSchedulerMeetings.Dtos;
using UsSchedulerMeetings.Services;

namespace UsSchedulerMeetings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public UsersController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet("{id}/meetings")]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetings(int id)
        {
            var participants = await _meetingService.GetUserMeetingsAsync(id);
            return Ok(participants);
        }
    }
}