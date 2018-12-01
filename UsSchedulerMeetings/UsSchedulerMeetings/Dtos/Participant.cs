using System;

namespace UsSchedulerMeetings.Dtos
{
    public class Participant
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MeetingId { get; set; }

        public DateTime Created { get; set; }
    }
}
