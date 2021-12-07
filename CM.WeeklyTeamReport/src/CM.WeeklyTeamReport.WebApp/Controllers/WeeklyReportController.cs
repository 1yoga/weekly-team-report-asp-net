using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.WeeklyTeamReport.Domain.Entites;
using CM.WeeklyTeamReport.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CM.WeeklyTeamReport.WebApp.Controllers
{
    [Route("api/companies/{companyId}/teammembers/{teamMemberId}/weeklyreports")]
    public class WeeklyReportController: ControllerBase
    {
        private IRepository<WeeklyReport> _repository;

        public WeeklyReportController(IRepository<WeeklyReport> repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public List<WeeklyReport> ReadAll(int teamMemberId)
        {
            return _repository.ReadAll(teamMemberId);
        }

        [HttpGet("{weeklyreportId}")]

        public WeeklyReport Read(int weeklyreportId)
        {
            return _repository.Read(weeklyreportId);
        }

        [HttpPut]
        public void Update([FromQuery] WeeklyReport weeklyreport)
        {
            _repository.Update(weeklyreport);
        }

        [HttpDelete]
        public void Delete([FromQuery] WeeklyReport weeklyreport)
        {
            _repository.Delete(weeklyreport);
        }

        [HttpPost]
        public WeeklyReport Create([FromQuery] WeeklyReport weeklyreport)
        {
            return _repository.Create(weeklyreport);
        }
    }
}
