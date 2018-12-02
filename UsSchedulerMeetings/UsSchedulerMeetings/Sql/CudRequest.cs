namespace UsSchedulerMeetings.Sql
{
    public class CudRequest
    {
        public const string CreateMeeting = @"
INSERT INTO Meetings ([Name], [Description], [CreatedBy], [StartDate], [StartTimeMinutes], [DurationMinutes], [Days])
VALUES (@Name, @Description, @CreatedBy, @StartDate, @StartTimeMinutes, @DurationMinutes, @Days)

SELECT CAST(SCOPE_IDENTITY() as int)";

        public const string CreateParticipant = @"
INSERT INTO Participants ([UserId], [MeetingId])
VALUES (@UserId, @MeetingId)

SELECT CAST(SCOPE_IDENTITY() as int)";

        public const string UpdateMeeting = @"
UPDATE Meeting SET
    Name = @Name,
    Description = @Desription,
    StartDate = @StartDate,
    StartTimeMinutes = @StartTimeMinutes,
    DurationMinutes = @DurationMinutes,
    Days = @Days
WHERE Id = @Id";

        public const string DeleteMeeting = @"UPDATE Meeting SET Active = 0 WHERE Id = @Id";

        public const string DeleteParticipant = @"DELETE FROM Participants WHERE Id = @Id";
    }
}
