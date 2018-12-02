namespace UsSchedulerMeetings.Sql
{
    public class GetRequests
    {
        public const string GetMeeting = @"SELECT * FROM Meetings WHERE Id = @MeetingId";

        public const string GetUserMeetings = @"
SELECT DISTINCT M.* FROM Meetings M
    INNER JOIN Participants P ON P.MeetingId = M.Id
WHERE P.UserId = @UserId";

        public const string GetCompanyMeetings = @"
SELECT DISTINCT M.* FROM Meetings M
    INNER JOIN Participants P ON P.MeetingId = M.Id
WHERE P.CompanyId = @CompanyId";

        public const string GetParticipants = @"SELECT * FROM Participants WHERE MeetingId = @MeetingId";
    }
}
