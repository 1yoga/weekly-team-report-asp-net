using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.WeeklyTeamReport.Domain.Entites;
using CM.WeeklyTeamReport.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CM.WeeklyTeamReport.WebApp.Controllers
{
    [Route("api/companies/{companyId}/teammembers")]
    public class TeamMemberController : ControllerBase
    {
        private IRepository<TeamMember> _repository;

        public TeamMemberController(IRepository<TeamMember> repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public List<TeamMember> ReadAll(int companyId)
        {
            return _repository.ReadAll(companyId);
        }

        [HttpGet("{teammemberId}")]

        public TeamMember Read(int teammemberId)
        {
            return _repository.Read(teammemberId);
        }

        [HttpPut]
        public void Update([FromQuery] TeamMember teammember)
        {
            _repository.Update(teammember);
        }

        [HttpDelete]
        public void Delete([FromQuery] TeamMember teammember)
        {
            _repository.Delete(teammember);
        }

        [HttpPost]
        public TeamMember Create([FromQuery] TeamMember teammember)
        {
            return _repository.Create(teammember);
        }
    }
}
