using System;
using Xunit;
using CM.WeeklyTeamReport.Domain.Repositories;
using FluentAssertions;
using CM.WeeklyTeamReport.Domain.Entites;

namespace CM.WeeklyTeamReport.Domain.IntegrationTests
{
    public class WeeklyReportTest
    {
        [Fact]
        public void ShouldBeAbleToCreateWeeklyReportRepository()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            weeklyReportRepository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToCreateWeeklyReportAndSaveItToDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();

            var weeklyReport = new WeeklyReport()
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

            weeklyReport = weeklyReportRepository.Create(weeklyReport);

            weeklyReport.Should().NotBeNull();
            weeklyReport.WeeklyReportId.Should().BeGreaterThan(0);
            weeklyReport.TeamMemberId.Should().Be(1);
            weeklyReport.MoraleLevel.Should().Be(5);
            weeklyReport.MoraleComment.Should().Be("Some Note");
            weeklyReport.StressLevel.Should().Be(5);
            weeklyReport.StressComment.Should().Be("Some Note");
            weeklyReport.WorkloadLevel.Should().Be(5);
            weeklyReport.WorkLoadComment.Should().Be("Some Note");
            weeklyReport.WeeklyHigh.Should().Be("Some Note");
            weeklyReport.WeeklyLow.Should().Be("Some Note");
            weeklyReport.AnythingElse.Should().Be("Some Note");
            weeklyReport.DateFrom.Should().Be(DateTime.Parse("08.11.2021"));
            weeklyReport.DateTo.Should().Be(DateTime.Parse("14.11.2021"));

        }

        [Fact]
        public void ShouldBeAbleToReadWeeklyReportFromDataBase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();

            var company = weeklyReportRepository.Read(1);

            company.Should().NotBeNull();
            company.WeeklyReportId.Should().Be(1);
        }

        [Fact]
        public void ShouldBeAbleToUpdateWeeklyReportAndSaveItToDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();

            var weeklyReport = new WeeklyReport()
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
            weeklyReportRepository.Update(weeklyReport);

            var updateTeamMember = weeklyReportRepository.Read(2);

            updateTeamMember.Should().NotBeNull();
            updateTeamMember.TeamMemberId.Should().Be(2);
            updateTeamMember.MoraleLevel.Should().Be(4);
            updateTeamMember.MoraleComment.Should().Be("Note");
            updateTeamMember.StressLevel.Should().Be(4);
            updateTeamMember.StressComment.Should().Be("Note");
            updateTeamMember.WorkloadLevel.Should().Be(4);
            updateTeamMember.WorkLoadComment.Should().Be("Note");
            updateTeamMember.WeeklyHigh.Should().Be("Note");
            updateTeamMember.WeeklyLow.Should().Be("Note");
            updateTeamMember.AnythingElse.Should().Be("Note");
            updateTeamMember.DateFrom.Should().Be(DateTime.Parse("18.11.2021"));
            updateTeamMember.DateTo.Should().Be(DateTime.Parse("24.11.2021"));
        }
        [Fact]
        public void ShouldBeAbleToDeleteWeeklyReportFromDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();

            var weeklyReport = new WeeklyReport()
            {
                WeeklyReportId = 3,
            };
            weeklyReportRepository.Delete(weeklyReport);

            var deleteWeeklyReport = weeklyReportRepository.Read(3);

            deleteWeeklyReport.Should().BeNull();
        }

    }
}
