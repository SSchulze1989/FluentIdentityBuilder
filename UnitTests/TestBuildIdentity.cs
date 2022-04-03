using FluentIdentityBuilder;
using System;
using System.Security.Claims;
using Xunit;

namespace UnitTests
{
    public class TestBuildIdentity
    {
        private const string defaultName = "Principal";
        private const string defaultId = "Identifier";
        private const string defaultAuthenticationType = "TestAuthentication";
        private const string defaultAuthenticationValue = "Authentication";
        private Claim defaultClaim1 = new Claim(ClaimTypes.Email, "Email");
        private Claim defaultClaim2 = new Claim(ClaimTypes.Uri, "www.principal.com");
        private const string defaultRole1 = "Role1";
        private const string defaultRole2 = "Role2";

        [Fact]
        public void BuildWithName()
        {
            var identity = IdentityBuilders.BuildIdentity()
                .WithName(defaultName)
                .Create();
            Assert.Equal(identity.Name, defaultName);
        }

        [Fact]
        public void BuildWithIdentifier()
        {
            var identity = IdentityBuilders.BuildIdentity()
                .WithIdentifier(defaultId)
                .Create();
            Assert.True(identity.HasClaim(ClaimTypes.NameIdentifier, defaultId));
        }

        [Fact]
        public void BuildWithClaims()
        {
            var identity = IdentityBuilders.BuildIdentity()
                .WithClaim(defaultClaim1.Type, defaultClaim1.Value)
                .WithClaim(defaultClaim2.Type, defaultClaim2.Value)
                .Create();
            Assert.True(identity.HasClaim(defaultClaim1.Type, defaultClaim1.Value));
            Assert.True(identity.HasClaim(defaultClaim2.Type, defaultClaim2.Value));
        }

        [Fact]
        public void BuildWithRoles()
        {
            var identity = IdentityBuilders.BuildIdentity()
                .WithRole(defaultRole1)
                .WithRole(defaultRole2)
                .Create();
            Assert.Contains(identity.Claims, x => x.Type == ClaimTypes.Role && x.Value == defaultRole1);
            Assert.Contains(identity.Claims, x => x.Type == ClaimTypes.Role && x.Value == defaultRole2);
        }

        [Fact]
        public void BuildWithAuthentication()
        {
            var identity = IdentityBuilders.BuildIdentity()
                .WithAuthentication(defaultAuthenticationType, defaultAuthenticationValue)
                .Create();
            Assert.True(identity.IsAuthenticated);
            Assert.True(identity.HasClaim(ClaimTypes.Authentication, defaultAuthenticationValue));
        }

        [Fact]
        public void OverrideName()
        {
            Assert.Throws<InvalidOperationException>(() => IdentityBuilders.BuildIdentity()
                .WithName("FalseName")
                .WithName(defaultName)
                .Create());
        }
    }
}
