using FluentIdentityBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class TestExtensions
    {
        private Claim claim1 = new Claim("Type1", "Value1");
        private Claim claim2 = new Claim("Type2", "Value2");
        private const string role1 = "Role1";
        private const string role2 = "Role2";

        [Fact]
        public void TestWithClaims()
        {
            var identity = StaticIdentityBuilders.BuildIdentity()
                .WithClaims(new Claim[] { claim1, claim2 })
                .Create();
            Assert.True(identity.HasClaim(claim1.Type, claim1.Value));
            Assert.True(identity.HasClaim(claim2.Type, claim2.Value));
        }

        [Fact]
        public void TestWithRoles()
        {
            var principal = StaticIdentityBuilders.BuildPrincipal()
                .WithRoles(new string[] { role1, role2 })
                .Create();
            Assert.True(principal.IsInRole(role1));
            Assert.True(principal.IsInRole(role2));
        }
    }
}
