using System;
using Xunit;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class CompanyTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCompany()
        {
            var company = new Company();
            company.CompanyName = "ANKO";
            Assert.Equal("ANKO", company.CompanyName);
        }
    }
}
