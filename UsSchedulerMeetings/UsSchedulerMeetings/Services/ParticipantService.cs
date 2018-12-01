using System.Collections.Generic;
using System.Threading.Tasks;
using UsSchedulerMeetings.Dtos;

namespace UsSchedulerMeetings.Services
{
    public class ParticipantService : IParticipantService
    {
        public Task<IEnumerable<Participant>> GetMeetingParticipantsAsync(int meetingId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Participant> CreateParticipantAsync(Participant dto)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteParticipantAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
