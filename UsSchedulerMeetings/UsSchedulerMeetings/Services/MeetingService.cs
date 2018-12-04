using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using UsSchedulerMeetings.Dtos;
using UsSchedulerMeetings.Settings;
using UsSchedulerMeetings.Sql;

namespace UsSchedulerMeetings.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly ConnectionStrings _connectionStrings;

        public MeetingService(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public async Task<Meeting> GetMeetingAsync(int id)
        {
            Meeting result;
            using (var conn = new SqlConnection(_connectionStrings.MeetingsDb))
            {
                var param = new DynamicParameters();
                param.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

                result = await conn.QuerySingleAsync<Meeting>(GetRequests.GetMeeting, param);
            }

            return result;
        }

        public async Task<IEnumerable<Meeting>> GetUserMeetingsAsync(int userId)
        {
            IEnumerable<Meeting> result;
            using (var conn = new SqlConnection(_connectionStrings.MeetingsDb))
            {
                var param = new DynamicParameters();
                param.Add("@UserId", userId, DbType.Int32, ParameterDirection.Input);

                result = await conn.QueryAsync<Meeting>(GetRequests.GetUserMeetings, param);
            } 

            //result = result.Where(x => x.StartDate.HasValue);
            return result;
        }

        public async Task<IEnumerable<Meeting>> GetCompanyMeetingsAsync(int companyId)
        {
            IEnumerable<Meeting> result;
            using (var conn = new SqlConnection(_connectionStrings.MeetingsDb))
            {
                var param = new DynamicParameters();
                param.Add("@CompanyId", companyId, DbType.Int32, ParameterDirection.Input);

                result = await conn.QueryAsync<Meeting>(GetRequests.GetCompanyMeetings, param);
            }

            return result;
        }

        public async Task<Meeting> CreateMeetingAsync(Meeting dto)
        {
            using (var conn = new SqlConnection(_connectionStrings.MeetingsDb))
            {
                var param = new DynamicParameters();
                param.Add("@Name", dto.Name, DbType.Int32, ParameterDirection.Input);
                param.Add("@Description", dto.Description, DbType.Int32, ParameterDirection.Input);
                param.Add("@CreatedBy", dto.CreatedBy, DbType.Int32, ParameterDirection.Input);
                param.Add("@CompanyId", dto.CompanyId, DbType.Int32, ParameterDirection.Input);
                param.Add("@StartDate", dto.StartDate, DbType.Int32, ParameterDirection.Input);
                param.Add("@StartTimeMinutes", dto.StartTimeMinutes, DbType.Int32, ParameterDirection.Input);
                param.Add("@DurationMinutes", dto.DurationMinutes, DbType.Int32, ParameterDirection.Input);
                param.Add("@Days", dto.Days, DbType.Int32, ParameterDirection.Input);

                dto.Id = await conn.QuerySingleAsync<int>(CudRequest.CreateMeeting, param);
            }

            return dto;
        }

        public async Task<Meeting> UpdateMeetingAsync(Meeting dto)
        {
            using (var conn = new SqlConnection(_connectionStrings.MeetingsDb))
            {
                var param = new DynamicParameters();
                param.Add("@Id", dto.Id, DbType.Int32, ParameterDirection.Input);
                param.Add("@Name", dto.Name, DbType.Int32, ParameterDirection.Input);
                param.Add("@Description", dto.Description, DbType.Int32, ParameterDirection.Input);
                param.Add("@StartDate", dto.StartDate, DbType.Int32, ParameterDirection.Input);
                param.Add("@StartTimeMinutes", dto.StartTimeMinutes, DbType.Int32, ParameterDirection.Input);
                param.Add("@DurationMinutes", dto.DurationMinutes, DbType.Int32, ParameterDirection.Input);
                param.Add("@Days", dto.Days, DbType.Int32, ParameterDirection.Input);

                await conn.ExecuteAsync(CudRequest.UpdateMeeting, param);
            }

            return dto;
        }

        public async Task DeleteMeetingAsync(int id)
        {
            using (var conn = new SqlConnection(_connectionStrings.MeetingsDb))
            {
                var param = new DynamicParameters();
                param.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

                await conn.ExecuteAsync(CudRequest.DeleteMeeting, param);
            }
        }
    }
}
