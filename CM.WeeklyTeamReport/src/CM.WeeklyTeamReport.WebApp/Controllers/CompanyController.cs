using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.WeeklyTeamReport.Domain.Entites;
using CM.WeeklyTeamReport.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CM.WeeklyTeamReport.WebApp.Controllers
{
    [Route("api/companies")]
    public class CompanyController: ControllerBase
    {
        private IRepository<Company> _repository;

        public CompanyController(IRepository<Company> repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public List<Company> ReadAll()
        {
            return _repository.ReadAll(null);
        }

        [HttpGet("{companyId}")]

        public Company Read(int companyId)
        {
            return _repository.Read(companyId);
        }

        [HttpPut]
        public void Update([FromQuery] Company company)
        {
            _repository.Update(company);
        }

        [HttpDelete]
        public void Delete([FromQuery] Company company)
        {
            _repository.Delete(company);
        }

        [HttpPost]
        public Company Create([FromQuery] Company company)
        {
            return _repository.Create(company);
        }
    }
}
