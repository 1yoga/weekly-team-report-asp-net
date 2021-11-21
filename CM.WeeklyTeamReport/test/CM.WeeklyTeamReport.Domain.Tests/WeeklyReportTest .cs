using System;
using Xunit;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class WeeklyReportTest
    {
        [Fact]
        public void ShouldBeAbleToCreateWeeklyReport()
        {
            var weeklyreport = new WeeklyReport()
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
            };

            Assert.Equal(1, weeklyreport.WeeklyReportId);
            Assert.Equal(1, weeklyreport.TeamMemberId);
            Assert.Equal(5, weeklyreport.MoraleLevel);
            Assert.Equal("Some Note", weeklyreport.MoraleComment);
            Assert.Equal(5, weeklyreport.StressLevel);
            Assert.Equal("Some Note", weeklyreport.StressComment);
            Assert.Equal(5, weeklyreport.WorkloadLevel);
            Assert.Equal("Some Note", weeklyreport.WorkLoadComment);
            Assert.Equal("Some Note", weeklyreport.WeeklyHigh);
            Assert.Equal("Some Note", weeklyreport.WeeklyLow);
            Assert.Equal("Some Note", weeklyreport.AnythingElse);
            Assert.Equal(DateTime.Parse("08.11.2021"), weeklyreport.DateFrom);
            Assert.Equal(DateTime.Parse("14.11.2021"), weeklyreport.DateTo);
        }
    }
}
