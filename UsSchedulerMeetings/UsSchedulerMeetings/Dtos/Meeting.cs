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

        public string Days { get; set; }

        public short StartTimeMinutes { get; set; }

        public int DurationMinutes { get; set; }

        public DateTime Created { get; set; }

        public int CompanyId { get; set; }

        public int CreatedBy { get; set; }

        public bool Active { get; set; }
    }
}
