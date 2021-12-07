using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Domain.Entites
{
    public class TeamMember
    {
        public int TeamMemberId { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        /*public TeamMember(int id, int companyid, string firstname, string lastname, string email)
        {
            TeamMemberId = id;
            CompanyId = companyid;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }*/
    }
}
