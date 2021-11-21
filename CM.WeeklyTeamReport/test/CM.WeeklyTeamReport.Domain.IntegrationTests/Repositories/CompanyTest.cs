using System;
using Xunit;
using CM.WeeklyTeamReport.Domain.Repositories;
using FluentAssertions;

namespace CM.WeeklyTeamReport.Domain.IntegrationTests
{
    public class CompanyTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCompanyRepository()
        {
            var companyRepository = new CompanyRepository();
            companyRepository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToCreateCompanyAndSaveItToDatabase()
        {
            var companyRepository = new CompanyRepository();

            var company = new Company();
            company.CompanyName = "ANKO";

            company = companyRepository.Create(company);

            company.Should().NotBeNull();
            company.CompanyId.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ShouldBeAbleToReadCompanyFromDataBase()
        {
            var companyRepository = new CompanyRepository();

            var company = companyRepository.Read(157);

            company.Should().NotBeNull();
            company.CompanyId.Should().Be(157);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCompanyAndSaveItToDatabase()
        {
            var companyRepository = new CompanyRepository();
            var company = new Company()
            {
                CompanyId = 158,
                CompanyName = "Google",
            };
            companyRepository.Update(company);

            var updateCompany = companyRepository.Read(158);

            updateCompany.Should().NotBeNull();
            updateCompany.CompanyName.Should().Be("Google");
        }
        [Fact]
        public void ShouldBeAbleToDeleteCompanyFromDatabase()
        {
            var companyRepository = new CompanyRepository();
            var company = new Company()
            {
                CompanyId = 5,
            };
            companyRepository.Delete(company);

            var deletedCompany = companyRepository.Read(1);

            deletedCompany.Should().BeNull();
        }

    }
}
