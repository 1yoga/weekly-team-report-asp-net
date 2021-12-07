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
    public class TeamMemberControllerTest
    {

        [Fact]
        public void ShouldBeReturnAllTeamMembersByCompanyId()
        {
            var fixture = new TeamMemberControllerFixture();
            fixture.TeamMemberRepository.Setup(x => x.ReadAll(158)).Returns(new List<TeamMember>()
            {
                new TeamMember(),
                new TeamMember()
            });

            var controller = fixture.GetTeamMemberController();
            var teammembers = controller.ReadAll(158);
            teammembers.Should().NotBeNull();
            teammembers.Should().HaveCount(2);
            fixture.TeamMemberRepository.Verify(x => x.ReadAll(158), Times.Once);
        }
        [Fact]
        public void ShouldBeReturnTeamMember()
        {
            var fixture = new TeamMemberControllerFixture();
            fixture.TeamMemberRepository.Setup(x => x.Read(100)).Returns(new TeamMember());
            var controller = fixture.GetTeamMemberController();
            var teammember = controller.Read(100);
            teammember.Should().NotBeNull();
            fixture.TeamMemberRepository.Verify(x => x.Read(100), Times.Once);
        }

        [Fact]
        public void ShouldBeUpdateTeamMember()
        {
            var fixture = new TeamMemberControllerFixture();
            var updatedTeamMember = new TeamMember()
            {
                TeamMemberId = 34,
                CompanyId = 161,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ibanov@gmail.com"
            };

            fixture.TeamMemberRepository.Setup(x => x.Update(updatedTeamMember));
            var controller = fixture.GetTeamMemberController();
            controller.Update(updatedTeamMember);

            fixture.TeamMemberRepository.Verify(x => x.Update(updatedTeamMember), Times.Once);
        }
        [Fact]
        public void ShouldBeDeleteTeamMember()
        {
            var fixture = new TeamMemberControllerFixture();
            var deletedTeamMember = new TeamMember()
            {
                TeamMemberId = 34,
            };

            fixture.TeamMemberRepository.Setup(x => x.Delete(deletedTeamMember));
            var controller = fixture.GetTeamMemberController();
            controller.Delete(deletedTeamMember);

            var teamMember = controller.Read(34);
            teamMember.Should().BeNull();
            fixture.TeamMemberRepository.Verify(x => x.Delete(deletedTeamMember), Times.Once);
        }

        [Fact]
        public void ShouldBeCreateTeamMember()
        {
            var fixture = new TeamMemberControllerFixture();
            var createdTeamMember = new TeamMember()
            {
                CompanyId = 161,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ibanov@gmail.com"
            };

            fixture.TeamMemberRepository.Setup(x => x.Create(createdTeamMember)).Returns(new TeamMember()
            {
                TeamMemberId = 1001,
                CompanyId = 161,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ibanov@gmail.com"

            });
            var controller = fixture.GetTeamMemberController();
            var teamMember = controller.Create(createdTeamMember);
            teamMember.Should().NotBeNull();
            teamMember.FirstName.Should().Be("Ivan");
            teamMember.TeamMemberId.Should().BeGreaterThan(0);
            fixture.TeamMemberRepository.Verify(x => x.Create(createdTeamMember), Times.Once);
        }
    }

    public class TeamMemberControllerFixture
    {
        public TeamMemberControllerFixture()
        {
            TeamMemberRepository = new Mock<IRepository<TeamMember>>();
        }

        public Mock<IRepository<TeamMember>> TeamMemberRepository { get; set; }

        public TeamMemberController GetTeamMemberController()
        {
            return new TeamMemberController(TeamMemberRepository.Object);
        }
    }
}
