using System.Collections.Generic;
using System.Threading.Tasks;
using UsSchedulerMeetings.Dtos;

namespace UsSchedulerMeetings.Services
{
    public interface IMeetingService
    {
        Task<Meeting> GetMeetingAsync(int userId);

        Task<IEnumerable<Meeting>> GetUserMeetingsAsync(int userId);

        Task<Meeting> CreateMeetingAsync(Meeting dto);

        Task<Meeting> UpdateMeetingAsync(Meeting dto);

        Task DeleteMeetingAsync(int id);
    }
}
