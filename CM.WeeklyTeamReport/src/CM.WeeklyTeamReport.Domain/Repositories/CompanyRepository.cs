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
    public class CompanyRepository : IRepository<Company>
    {

        private SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection("Server=DESKTOP-PKV4PAF; Database=WeeklyReport_DB;Trusted_Connection=True;");
            connection.Open();
            return connection;
        }
        private static Company MapCompany(SqlDataReader reader)
        {
            return new Company()
            {
                CompanyName = (string)reader["CompanyName"],
                CompanyId = (int)reader["CompanyId"],
            };
        }
        public Company Create(Company entity)
        {
            using(var connection = GetSqlConnection())
            {
                var command = new SqlCommand("INSERT INTO Companies (CompanyName)" +
                                             "VALUES (@CompanyName)" +
                                             "SELECT * FROM Companies WHERE CompanyId = SCOPE_IDENTITY()"
                    , connection);

                var companyNameParam = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.CompanyName
                };

                command.Parameters.Add(companyNameParam);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return MapCompany(reader);
                }
                return null;
            }
        }
        public Company Read(int entityId)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("SELECT * FROM Companies WHERE CompanyId = @CompanyId"
                    , connection);

                var companyIdParam = new SqlParameter("@CompanyId", SqlDbType.Int)
                {
                    Value = entityId
                };

                command.Parameters.Add(companyIdParam);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return MapCompany(reader);
                }
                return null;
            }
        }

        
        public void Update(Company entity)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("UPDATE Companies" + " SET CompanyName = @CompanyName " + "WHERE CompanyId = @CompanyId", connection);
                var companyNameParam = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.CompanyName
                };
                var companyIdParam = new SqlParameter("@CompanyId", SqlDbType.Int)
                {
                    Value = entity.CompanyId
                };
                command.Parameters.Add(companyNameParam);
                command.Parameters.Add(companyIdParam);

                command.ExecuteNonQuery();
            }

        }
        public void Delete(Company entity)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("DELETE Companies" + " WHERE CompanyId = @CompanyId", connection);
                
                var companyIdParam = new SqlParameter("@CompanyId", SqlDbType.Int)
                {
                    Value = entity.CompanyId
                };
                command.Parameters.Add(companyIdParam);

                command.ExecuteNonQuery();

            }
        }

        public List<Company> ReadAll(int? id)
        {
            List<Company> companies = new List<Company>();
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("SELECT * FROM Companies"
                    , connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var company = MapCompany(reader);
                    companies.Add(company);
                }

                return companies;
            }
        }
    }
}
