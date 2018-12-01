using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using UsSchedulerMeetings.Dtos;
using UsSchedulerMeetings.Settings;
using UsSchedulerMeetings.Sql;

namespace UsSchedulerMeetings.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly ConnectionStrings _connectionStrings;

        public ParticipantService(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public async Task<IEnumerable<Participant>> GetMeetingParticipantsAsync(int meetingId)
        {
            IEnumerable<Participant> result;
            using (var conn = new SqlConnection(_connectionStrings.MeetingsDb))
            {
                var param = new DynamicParameters();
                param.Add("@MeetingId", meetingId, DbType.Int32, ParameterDirection.Input);

                result = await conn.QueryAsync<Participant>(GetRequests.GetParticipants, param);
            }

            return result;
        }

        public async Task<Participant> CreateParticipantAsync(Participant dto)
        {
            using (var conn = new SqlConnection(_connectionStrings.MeetingsDb))
            {
                var param = new DynamicParameters();
                param.Add("@UserId", dto.UserId, DbType.Int32, ParameterDirection.Input);
                param.Add("@MeetingId", dto.MeetingId, DbType.Int32, ParameterDirection.Input);
                
                dto.Id = await conn.QuerySingleAsync<int>(CudRequest.CreateParticipant, param);
            }

            return dto;
        }

        public async Task DeleteParticipantAsync(int id)
        {
            using (var conn = new SqlConnection(_connectionStrings.MeetingsDb))
            {
                var param = new DynamicParameters();
                param.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
                
                await conn.QuerySingleAsync<int>(CudRequest.DeleteParticipant, param);
            }
        }
    }
}
