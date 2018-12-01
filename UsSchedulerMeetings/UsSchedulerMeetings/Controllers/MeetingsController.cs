using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsSchedulerMeetings.Dtos;
using UsSchedulerMeetings.Services;

namespace UsSchedulerMeetings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        private readonly IParticipantService _participantService;

        public MeetingsController(IMeetingService meetingService, IParticipantService participantService)
        {
            _meetingService = meetingService;
            _participantService = participantService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> Get(int id)
        {
            var meeting = await _meetingService.GetMeetingAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            return Ok(meeting);
        }

        [HttpGet("{id}/participants")]
        public async Task<ActionResult<Meeting>> GetParticipants(int id)
        {
            var participants = await _participantService.GetMeetingParticipantsAsync(id);
            return Ok(participants);
        }

        [HttpPost]
        public async Task<ActionResult<Meeting>> Create([FromBody] Meeting dto)
        {
            return await _meetingService.CreateMeetingAsync(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Meeting>> Update([FromBody] Meeting dto)
        {
            return await _meetingService.UpdateMeetingAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _meetingService.DeleteMeetingAsync(id);
            return Ok();
        }
    }
}