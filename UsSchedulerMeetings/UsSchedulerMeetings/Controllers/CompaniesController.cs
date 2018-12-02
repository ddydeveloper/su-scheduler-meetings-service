using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsSchedulerMeetings.Dtos;
using UsSchedulerMeetings.Services;

namespace UsSchedulerMeetings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public CompaniesController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet("{id}/meetings")]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetings(int id)
        {
            var meetings = await _meetingService.GetCompanyMeetingsAsync(id);
            return Ok(meetings);
        }
    }
}