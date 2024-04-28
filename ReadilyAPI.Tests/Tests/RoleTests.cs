using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Domain;
using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Tests.Tests
{
    public class RoleTests : IClassFixture<DatabaseFixture>
    {
        protected readonly DatabaseFixture _fixture;

        public RoleTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddRole()
        {
            Role role = new Role
            {
                Name = "Test",
            };

            _fixture.Context.Entry(role).State.Should().Be(EntityState.Detached);

            _fixture.Context.Roles.Add(role);

            _fixture.Context.Entry(role).State.Should().Be(EntityState.Added);

            _fixture.Context.SaveChanges();

            role = _fixture.Context.Roles.FirstOrDefault(x => x.Name == "Test");

            role.Should().NotBeNull();
            role.Name.Should().Be("Test");
            role.IsActive.Should().BeTrue();
            role.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(500));

            _fixture.Context.Entry(role).State.Should().Be(EntityState.Unchanged);

            role.CreatedAt = DateTime.Now;

            _fixture.Context.Entry(role).State.Should().Be(EntityState.Modified);

            _fixture.Context.SaveChanges();
        }
    }
}
