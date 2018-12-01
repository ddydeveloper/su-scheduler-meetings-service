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
        private readonly IParticipantService _participantService;

        public UsersController(IMeetingService meetingService, IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet("{id}/meetings")]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetings(int id)
        {
            var participants = await _participantService.GetMeetingParticipantsAsync(id);
            return Ok(participants);
        }
    }
}