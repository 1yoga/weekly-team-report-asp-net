using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Domain.Repositories
{
    public class TeamMemberRepository : IRepository<TeamMember>
    {

        private SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection("Server=DESKTOP-PKV4PAF; Database=WeeklyReport_DB;Trusted_Connection=True;");
            connection.Open();
            return connection;
        }
        private static TeamMember MapTeamMember(SqlDataReader reader)
        {
            return new TeamMember()
            {
                TeamMemberId = (int)reader["TeamMemberId"],
                CompanyId = (int)reader["CompanyId"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Email = (string)reader["Email"],
            };
        }
        public TeamMember Create(TeamMember entity)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("INSERT INTO TeamMembers (CompanyId, FirstName, LastName, Email)" +
                                             "VALUES (@CompanyId, @FirstName, @LastName, @Email)" +
                                             "SELECT * FROM TeamMembers WHERE TeamMemberId = SCOPE_IDENTITY()"
                    , connection);

                var companyIdParam = new SqlParameter("@CompanyId", SqlDbType.Int)
                {
                    Value = entity.CompanyId
                };
                var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.FirstName
                };
                var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.LastName
                };
                var emailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 50)
                {
                    Value = entity.Email
                };

                command.Parameters.Add(companyIdParam);
                command.Parameters.Add(firstNameParam);
                command.Parameters.Add(lastNameParam);
                command.Parameters.Add(emailParam);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return MapTeamMember(reader);
                }
                return null;
            }
        }
        public TeamMember Read(int entityId)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("SELECT * FROM TeamMembers WHERE TeamMemberId = @TeamMemberId"
                    , connection);

                var temMemberIdParam = new SqlParameter("TeamMemberId", SqlDbType.Int)
                {
                    Value = entityId
                };

                command.Parameters.Add(temMemberIdParam);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return MapTeamMember(reader);
                }
                return null;
            }
        }

        

        public void Update(TeamMember entity)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("UPDATE TeamMembers" + 
                                             " SET CompanyId = @CompanyId, FirstName = @FirstName, LastName = @LastName, Email = @Email " + 
                                             "WHERE TeamMemberId = @TeamMemberId", connection);
                var companyIdParam = new SqlParameter("@CompanyId", SqlDbType.Int)
                {
                    Value = entity.CompanyId
                };
                var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.FirstName
                };
                var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.LastName
                };
                var emailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 50)
                {
                    Value = entity.Email
                }; 
                var temMemberIdParam = new SqlParameter("TeamMemberId", SqlDbType.Int)
                {
                    Value = entity.TeamMemberId
                };

                command.Parameters.Add(companyIdParam);
                command.Parameters.Add(firstNameParam);
                command.Parameters.Add(lastNameParam);
                command.Parameters.Add(emailParam);
                command.Parameters.Add(temMemberIdParam);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(TeamMember entity)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("DELETE TeamMembers" + " WHERE TeamMemberId = @TeamMemberId", connection);

                var temMemberIdParam = new SqlParameter("TeamMemberId", SqlDbType.Int)
                {
                    Value = entity.TeamMemberId
                };
                command.Parameters.Add(temMemberIdParam);

                command.ExecuteNonQuery();

            }
        }
    }
}
