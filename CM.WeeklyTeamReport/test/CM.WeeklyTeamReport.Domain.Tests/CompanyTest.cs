using System;
using CM.WeeklyTeamReport.Domain.Entites;
using Xunit;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class CompanyTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCompany()
        {
            var company = new Company
            {
                CompanyName = "Google"
            };
            Assert.Equal("Google", company.CompanyName);
        }
    }
}
