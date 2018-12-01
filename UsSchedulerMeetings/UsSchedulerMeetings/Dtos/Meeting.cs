using System;
using System.Collections.Generic;

namespace UsSchedulerMeetings.Dtos
{
    public class Meeting
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public List<int> Days { get; set; }

        public TimeSpan StartTime { get; set; }

        public int DurationMinutes { get; set; }

        public DateTime Created { get; set; }

        public int Author { get; set; }

        public bool Active { get; set; }
    }
}
