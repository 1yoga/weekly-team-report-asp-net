using System;
using CM.WeeklyTeamReport.Domain.Entites;
using Xunit;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class TeamMemberTest
    {
        [Fact]
        public void ShouldBeAbleToCreateTeamMember()
        {
            var teammember = new TeamMember
            {
                CompanyId = 1,
                TeamMemberId = 1,
                FirstName = "Anton",
                LastName = "Kazakevich",
                Email = "1yoga@mail.ru"
            };
            Assert.Equal(1, teammember.TeamMemberId);
            Assert.Equal(1, teammember.CompanyId);
            Assert.Equal("Anton", teammember.FirstName);
            Assert.Equal("Kazakevich", teammember.LastName);
            Assert.Equal("1yoga@mail.ru", teammember.Email);
        }
    }
}
