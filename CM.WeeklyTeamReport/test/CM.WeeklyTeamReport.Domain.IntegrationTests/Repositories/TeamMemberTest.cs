using System;
using Xunit;
using CM.WeeklyTeamReport.Domain.Repositories;
using FluentAssertions;

namespace CM.WeeklyTeamReport.Domain.IntegrationTests
{
    public class TeamMemberTest
    {
        [Fact]
        public void ShouldBeAbleToCreateTeamMemberRepository()
        {
            var teamMemberRepository = new TeamMemberRepository();
            teamMemberRepository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToCreateTeamMemberAndSaveItToDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();

            var teamMember = new TeamMember
            {
                CompanyId = 157,
                FirstName = "Anton",
                LastName = "Kazakevich",
                Email = "1yoga@mail.ru"
            };

            teamMember = teamMemberRepository.Create(teamMember);

            teamMember.Should().NotBeNull();
            teamMember.CompanyId.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ShouldBeAbleToReadTeamMemberFromDataBase()
        {
            var teamMemberRepository = new TeamMemberRepository();

            var teamMember = teamMemberRepository.Read(1);

            teamMember.Should().NotBeNull();
            teamMember.TeamMemberId.Should().Be(1);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCompanyAndSaveItToDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();

            var teamMember = new TeamMember
            {
                TeamMemberId = 1,
                CompanyId = 158,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivanova@mail.ru"
            };
            teamMemberRepository.Update(teamMember);

            var updateTeamMember = teamMemberRepository.Read(1);

            updateTeamMember.Should().NotBeNull();
            updateTeamMember.CompanyId.Should().Be(158);
            updateTeamMember.FirstName.Should().Be("Ivan");
            updateTeamMember.LastName.Should().Be("Ivanov");
            updateTeamMember.Email.Should().Be("ivanova@mail.ru");
        }
        [Fact]
        public void ShouldBeAbleToDeleteCompanyFromDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();
            var teamMember = new TeamMember
            {
                TeamMemberId = 5,
            };
            teamMemberRepository.Delete(teamMember);

            var deletedTeamMember = teamMemberRepository.Read(5);

            deletedTeamMember.Should().BeNull();
        }

    }
}
