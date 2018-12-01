using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using UsSchedulerMeetings.Dtos;
using UsSchedulerMeetings.Settings;

namespace UsSchedulerMeetings.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly ConnectionStrings _connectionStrings;

        public MeetingService(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public Task<Meeting> GetMeetingAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Meeting>> GetUserMeetingsAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Meeting> CreateMeetingAsync(Meeting dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<Meeting> UpdateMeetingAsync(Meeting dto)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMeetingAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
