using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.WeeklyTeamReport.Domain.Entites;

namespace CM.WeeklyTeamReport.Domain.Repositories
{
    public class WeeklyReportRepository : IRepository<WeeklyReport>
    {

        private SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection("Server=DESKTOP-PKV4PAF; Database=WeeklyReport_DB;Trusted_Connection=True;");
            connection.Open();
            return connection;
        }
        private static WeeklyReport MapCompany(SqlDataReader reader)
        {
            return new WeeklyReport()
            {
                WeeklyReportId = (int)reader["WeeklyReportId"],
                TeamMemberId = (int)reader["TeamMemberId"],
                MoraleLevel = (int)reader["MoraleLevel"],
                MoraleComment = (string)reader["MoraleComment"],
                StressLevel = (int)reader["StressLevel"],
                StressComment = (string)reader["StressComment"],
                WorkloadLevel = (int)reader["WorkloadLevel"],
                WorkLoadComment = (string)reader["WorkLoadComment"],
                WeeklyHigh = (string)reader["WeeklyHigh"],
                WeeklyLow = (string)reader["WeeklyLow"],
                AnythingElse = (string)reader["AnythingElse"],
                DateFrom = (DateTime)reader["DateFrom"],
                DateTo = (DateTime)reader["DateTo"]
            };
        }
        public WeeklyReport Create(WeeklyReport entity)
        {
            using(var connection = GetSqlConnection())
            {
                var command = new SqlCommand("INSERT INTO WeeklyReports (TeamMemberId, MoraleLevel, MoraleComment, StressLevel, StressComment, WorkloadLevel, WorkLoadComment, WeeklyHigh, WeeklyLow, AnythingElse, DateFrom, DateTo)" +
                                             "VALUES (@TeamMemberId, @MoraleLevel, @MoraleComment, @StressLevel, @StressComment, @WorkloadLevel, @WorkLoadComment, @WeeklyHigh, @WeeklyLow, @AnythingElse, @DateFrom, @DateTo)" +
                                             "SELECT * FROM WeeklyReports WHERE WeeklyReportId = SCOPE_IDENTITY()"
                    , connection);


                
                var teamMemberIdParam = new SqlParameter("@TeamMemberId", SqlDbType.Int)
                {
                    Value = entity.TeamMemberId
                };
                var moraleLevelParam = new SqlParameter("@MoraleLevel", SqlDbType.Int)
                {
                    Value = entity.MoraleLevel
                };
                var stressLevelParam = new SqlParameter("@StressLevel", SqlDbType.Int)
                {
                    Value = entity.StressLevel
                };
                var workloadLevelParam = new SqlParameter("@WorkloadLevel", SqlDbType.Int)
                {
                    Value = entity.WorkloadLevel
                };
                var moraleCommentParam = new SqlParameter("@MoraleComment", SqlDbType.NVarChar, 300)
                {
                    Value = entity.MoraleComment
                };
                var stressCommentParam = new SqlParameter("@StressComment", SqlDbType.NVarChar, 300)
                {
                    Value = entity.StressComment
                }; 
                var workLoadCommentParam = new SqlParameter("@WorkLoadComment", SqlDbType.NVarChar, 300)
                {
                    Value = entity.WorkLoadComment
                };
                var weeklyHighParam = new SqlParameter("@WeeklyHigh", SqlDbType.NVarChar, 300)
                {
                    Value = entity.WeeklyHigh
                };
                var weeklyLowParam = new SqlParameter("@WeeklyLow", SqlDbType.NVarChar, 300)
                {
                    Value = entity.WeeklyLow
                };
                var anythingElseParam = new SqlParameter("@AnythingElse", SqlDbType.NVarChar, 300)
                {
                    Value = entity.AnythingElse
                };
                var dateFromParam = new SqlParameter("@DateFrom", SqlDbType.Date)
                {
                    Value = entity.DateFrom
                };
                var dateToParam = new SqlParameter("@DateTo", SqlDbType.Date)
                {
                    Value = entity.DateTo
                };


                command.Parameters.Add(teamMemberIdParam);
                command.Parameters.Add(moraleLevelParam);
                command.Parameters.Add(stressLevelParam);
                command.Parameters.Add(workloadLevelParam);
                command.Parameters.Add(moraleCommentParam);
                command.Parameters.Add(stressCommentParam);
                command.Parameters.Add(workLoadCommentParam);
                command.Parameters.Add(weeklyHighParam);
                command.Parameters.Add(weeklyLowParam);
                command.Parameters.Add(anythingElseParam);
                command.Parameters.Add(dateFromParam);
                command.Parameters.Add(dateToParam);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return MapCompany(reader);
                }
                return null;
            }
        }
        public WeeklyReport Read(int entityId)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("SELECT * FROM WeeklyReports WHERE WeeklyReportId = @WeeklyReportId"
                    , connection);

                var weeklyReportIdParam = new SqlParameter("@WeeklyReportId", SqlDbType.Int)
                {
                    Value = entityId
                };

                command.Parameters.Add(weeklyReportIdParam);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return MapCompany(reader);
                }
                return null;
            }
        }

        

        public void Update(WeeklyReport entity)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand(
                    "UPDATE WeeklyReports" +
                    " SET TeamMemberId = @TeamMemberId, MoraleLevel = @MoraleLevel, MoraleComment = @MoraleComment, StressLevel = @StressLevel, StressComment = @StressComment, WorkloadLevel = @WorkloadLevel, WorkLoadComment = @WorkLoadComment, WeeklyHigh = @WeeklyHigh, WeeklyLow = @WeeklyLow, AnythingElse = @AnythingElse, DateFrom = @DateFrom, DateTo = @DateTo " +
                    "WHERE WeeklyReportId = @WeeklyReportId"
                    , connection);

                var teamMemberIdParam = new SqlParameter("@TeamMemberId", SqlDbType.Int)
                {
                    Value = entity.TeamMemberId
                };
                var moraleLevelParam = new SqlParameter("@MoraleLevel", SqlDbType.Int)
                {
                    Value = entity.MoraleLevel
                };
                var stressLevelParam = new SqlParameter("@StressLevel", SqlDbType.Int)
                {
                    Value = entity.StressLevel
                };
                var workloadLevelParam = new SqlParameter("@WorkloadLevel", SqlDbType.Int)
                {
                    Value = entity.WorkloadLevel
                };
                var moraleCommentParam = new SqlParameter("@MoraleComment", SqlDbType.NVarChar, 300)
                {
                    Value = entity.MoraleComment
                };
                var stressCommentParam = new SqlParameter("@StressComment", SqlDbType.NVarChar, 300)
                {
                    Value = entity.StressComment
                };
                var workLoadCommentParam = new SqlParameter("@WorkLoadComment", SqlDbType.NVarChar, 300)
                {
                    Value = entity.WorkLoadComment
                };
                var weeklyHighParam = new SqlParameter("@WeeklyHigh", SqlDbType.NVarChar, 300)
                {
                    Value = entity.WeeklyHigh
                };
                var weeklyLowParam = new SqlParameter("@WeeklyLow", SqlDbType.NVarChar, 300)
                {
                    Value = entity.WeeklyLow
                };
                var anythingElseParam = new SqlParameter("@AnythingElse", SqlDbType.NVarChar, 300)
                {
                    Value = entity.AnythingElse
                };
                var dateFromParam = new SqlParameter("@DateFrom", SqlDbType.Date)
                {
                    Value = entity.DateFrom
                };
                var dateToParam = new SqlParameter("@DateTo", SqlDbType.Date)
                {
                    Value = entity.DateTo
                };
                var weeklyReportIdParam = new SqlParameter("@WeeklyReportId", SqlDbType.Int)
                {
                    Value = entity.WeeklyReportId
                };


                command.Parameters.Add(teamMemberIdParam);
                command.Parameters.Add(moraleLevelParam);
                command.Parameters.Add(stressLevelParam);
                command.Parameters.Add(workloadLevelParam);
                command.Parameters.Add(moraleCommentParam);
                command.Parameters.Add(stressCommentParam);
                command.Parameters.Add(workLoadCommentParam);
                command.Parameters.Add(weeklyHighParam);
                command.Parameters.Add(weeklyLowParam);
                command.Parameters.Add(anythingElseParam);
                command.Parameters.Add(dateFromParam);
                command.Parameters.Add(dateToParam);
                command.Parameters.Add(weeklyReportIdParam);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(WeeklyReport entity)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("DELETE WeeklyReports" + " WHERE WeeklyReportId = @WeeklyReportId", connection);

                var weeklyReportIdParam = new SqlParameter("@WeeklyReportId", SqlDbType.Int)
                {
                    Value = entity.WeeklyReportId
                };
                command.Parameters.Add(weeklyReportIdParam);

                command.ExecuteNonQuery();

            }
        }

        public List<WeeklyReport> ReadAll(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
