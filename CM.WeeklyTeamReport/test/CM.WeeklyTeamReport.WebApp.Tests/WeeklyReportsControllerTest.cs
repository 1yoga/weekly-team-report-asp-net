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
    public class WeeklyReportsControllerTest
    {
        [Fact]
        public void ShouldBeReturnAllWeeklyReportsByTeamMemberId()
        {
            var fixture = new WeeklyReportControllerFixture();
            fixture.WeeklyReportRepository.Setup(x => x.ReadAll(15)).Returns(new List<WeeklyReport>()
            {
                new WeeklyReport(),
                new WeeklyReport()
            });

            var controller = fixture.GetWeeklyReportController();
            var weeklyreports = controller.ReadAll(15);
            weeklyreports.Should().NotBeNull();
            weeklyreports.Should().HaveCount(2);
            fixture.WeeklyReportRepository.Verify(x => x.ReadAll(15), Times.Once);
        }
        [Fact]
        public void ShouldBeReturnWeeklyReport()
        {
            var fixture = new WeeklyReportControllerFixture();
            fixture.WeeklyReportRepository.Setup(x => x.Read(10)).Returns(new WeeklyReport());
            var controller = fixture.GetWeeklyReportController();
            var weeklyReport = controller.Read(10);
            weeklyReport.Should().NotBeNull();
            fixture.WeeklyReportRepository.Verify(x => x.Read(10), Times.Once);
        }

        [Fact]
        public void ShouldBeUpdateWeeklyReport()
        {
            var fixture = new WeeklyReportControllerFixture();
            var updatedWeeklyReport = new WeeklyReport()
            {
                WeeklyReportId = 2,
                TeamMemberId = 2,
                MoraleLevel = 4,
                MoraleComment = "Note",
                StressLevel = 4,
                StressComment = "Note",
                WorkloadLevel = 4,
                WorkLoadComment = "Note",
                WeeklyHigh = "Note",
                WeeklyLow = "Note",
                AnythingElse = "Note",
                DateFrom = DateTime.Parse("18.11.2021"),
                DateTo = DateTime.Parse("24.11.2021")
            };

            fixture.WeeklyReportRepository.Setup(x => x.Update(updatedWeeklyReport));
            var controller = fixture.GetWeeklyReportController();
            controller.Update(updatedWeeklyReport);

            fixture.WeeklyReportRepository.Verify(x => x.Update(updatedWeeklyReport), Times.Once);
        }
        [Fact]
        public void ShouldBeDeleteWeeklyReport()
        {
            var fixture = new WeeklyReportControllerFixture();
            var deletedWeeklyReport = new WeeklyReport()
            {
                WeeklyReportId = 2
            };

            fixture.WeeklyReportRepository.Setup(x => x.Delete(deletedWeeklyReport));
            var controller = fixture.GetWeeklyReportController();
            controller.Delete(deletedWeeklyReport);

            var weeklyReport = controller.Read(34);
            weeklyReport.Should().BeNull();
            fixture.WeeklyReportRepository.Verify(x => x.Delete(deletedWeeklyReport), Times.Once);
        }

        [Fact]
        public void ShouldBeCreateWeeklyReport()
        {
            var fixture = new WeeklyReportControllerFixture();
            var createdWeeklyReport = new WeeklyReport()
            {
                TeamMemberId = 1,
                MoraleLevel = 5,
                MoraleComment = "Some Note",
                StressLevel = 5,
                StressComment = "Some Note",
                WorkloadLevel = 5,
                WorkLoadComment = "Some Note",
                WeeklyHigh = "Some Note",
                WeeklyLow = "Some Note",
                AnythingElse = "Some Note",
                DateFrom = DateTime.Parse("08.11.2021"),
                DateTo = DateTime.Parse("14.11.2021")
            };

            fixture.WeeklyReportRepository.Setup(x => x.Create(createdWeeklyReport)).Returns(new WeeklyReport()
            {
                WeeklyReportId = 1,
                TeamMemberId = 1,
                MoraleLevel = 5,
                MoraleComment = "Some Note",
                StressLevel = 5,
                StressComment = "Some Note",
                WorkloadLevel = 5,
                WorkLoadComment = "Some Note",
                WeeklyHigh = "Some Note",
                WeeklyLow = "Some Note",
                AnythingElse = "Some Note",
                DateFrom = DateTime.Parse("08.11.2021"),
                DateTo = DateTime.Parse("14.11.2021")

            });
            var controller = fixture.GetWeeklyReportController();
            var teamMember = controller.Create(createdWeeklyReport);
            teamMember.Should().NotBeNull();
            teamMember.MoraleComment.Should().Be("Some Note");
            teamMember.TeamMemberId.Should().BeGreaterThan(0);
            fixture.WeeklyReportRepository.Verify(x => x.Create(createdWeeklyReport), Times.Once);
        }
    }

    public class WeeklyReportControllerFixture
    {
        public WeeklyReportControllerFixture()
        {
            WeeklyReportRepository = new Mock<IRepository<WeeklyReport>>();
        }

        public Mock<IRepository<WeeklyReport>> WeeklyReportRepository { get; set; }

        public WeeklyReportController GetWeeklyReportController()
        {
            return new WeeklyReportController(WeeklyReportRepository.Object);
        }
    }
}

