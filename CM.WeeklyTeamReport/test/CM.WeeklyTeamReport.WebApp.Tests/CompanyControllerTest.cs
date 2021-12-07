using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using CM.WeeklyTeamReport.Domain.Entites;
using CM.WeeklyTeamReport.Domain.Repositories;
using CM.WeeklyTeamReport.WebApp.Controllers;
using FluentAssertions;
using Moq;
using Xunit;

namespace CM.WeeklyTeamReport.WebApp.Tests
{
    public class CompanyControllerTest
    {
        [Fact]
        public void ShouldBeReturnAllCompanies()
        {
            var fixture = new CompanyControllerFixture();

            fixture.CompanyRepository.Setup(x => x.ReadAll(null)).Returns(new List<Company>()
            {
                new Company()
            });
            var controller = fixture.GetCompanyController();
            var companies = controller.ReadAll();
            companies.Should().NotBeNull();
            companies.Should().HaveCount(1);
            fixture.CompanyRepository.Verify(x=>x.ReadAll(null), Times.Once);
        }
        [Fact]
        public void ShouldBeReturnCompany()
        {
            var fixture = new CompanyControllerFixture();
            fixture.CompanyRepository.Setup(x => x.Read(158)).Returns(new Company());
            var controller = fixture.GetCompanyController();
            var company = controller.Read(158);
            company.Should().NotBeNull();
            fixture.CompanyRepository.Verify(x => x.Read(158), Times.Once);
        }

        [Fact]
        public void ShouldBeUpdateCompany()
        {
            var fixture = new CompanyControllerFixture();
            var updatedCompany = new Company()
            {
                CompanyId = 161,
                CompanyName = "Facebook"
            };

            fixture.CompanyRepository.Setup(x => x.Update(updatedCompany));
            var controller = fixture.GetCompanyController();
            controller.Update(updatedCompany);

            fixture.CompanyRepository.Verify(x => x.Update(updatedCompany), Times.Once);
        }
        [Fact]
        public void ShouldBeDeleteCompany()
        {
            var fixture = new CompanyControllerFixture();
            var deletedCompany = new Company()
            {
                CompanyId = 160,
                CompanyName = "ANKO"
            };

            fixture.CompanyRepository.Setup(x => x.Delete(deletedCompany));
            var controller = fixture.GetCompanyController();
            controller.Delete(deletedCompany);

            var company = controller.Read(160);
            company.Should().BeNull();
            fixture.CompanyRepository.Verify(x => x.Delete(deletedCompany), Times.Once);
        }

        [Fact]
        public void ShouldBeCreateCompany()
        {
            var fixture = new CompanyControllerFixture();
            var createCompany = new Company()
            {
                CompanyName = "Amazon"
            };

            fixture.CompanyRepository.Setup(x => x.Create(createCompany)).Returns(new Company()
            {
                CompanyId = 1001,
                CompanyName = "Amazon"
                
            });
            var controller = fixture.GetCompanyController();
            var company = controller.Create(createCompany);
            company.Should().NotBeNull();
            company.CompanyName.Should().Be("Amazon");
            company.CompanyId.Should().BeGreaterThan(0);
            fixture.CompanyRepository.Verify(x => x.Create(createCompany), Times.Once);
        }
    }

    public class CompanyControllerFixture
    {
        public CompanyControllerFixture()
        {
            CompanyRepository = new Mock<IRepository<Company>>();
        }

        public Mock<IRepository<Company>> CompanyRepository { get; set; }

        public CompanyController GetCompanyController()
        {
            return new CompanyController(CompanyRepository.Object);
        }
    }
    
}
