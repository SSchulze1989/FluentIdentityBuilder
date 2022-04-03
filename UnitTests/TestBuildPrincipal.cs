using FluentIdentityBuilder;
using System;
using System.Security.Claims;
using Xunit;

namespace UnitTests
{
    public class TestBuildPrincipal
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
            var principal = IdentityBuilders.BuildPrincipal()
                .WithName(defaultName)
                .Create();
            Assert.Equal(principal.Identity.Name, defaultName);
        }

        [Fact]
        public void BuildWithIdentifier()
        {
            var principal = IdentityBuilders.BuildPrincipal()
                .WithIdentifier(defaultId)
                .Create();
            Assert.True(principal.HasClaim(ClaimTypes.NameIdentifier, defaultId));
        }

        [Fact]
        public void BuildWithClaims()
        {
            var principal = IdentityBuilders.BuildPrincipal()
                .WithClaim(defaultClaim1.Type, defaultClaim1.Value)
                .WithClaim(defaultClaim2.Type, defaultClaim2.Value)
                .Create();
            Assert.True(principal.HasClaim(defaultClaim1.Type, defaultClaim1.Value));
            Assert.True(principal.HasClaim(defaultClaim2.Type, defaultClaim2.Value));
        }

        [Fact]
        public void BuildWithRoles()
        {
            var principal = IdentityBuilders.BuildPrincipal()
                .WithRole(defaultRole1)
                .WithRole(defaultRole2)
                .Create();
            Assert.True(principal.IsInRole(defaultRole1));
            Assert.True(principal.IsInRole(defaultRole2));
        }

        [Fact]
        public void BuildWithAuthentication()
        {
            var principal = IdentityBuilders.BuildPrincipal()
                .WithAuthentication(defaultAuthenticationType, defaultAuthenticationValue)
                .Create();
            Assert.True(principal.Identity.IsAuthenticated);
            Assert.True(principal.HasClaim(ClaimTypes.Authentication, defaultAuthenticationValue));
        }

        [Fact]
        public void OverrideName()
        {
            Assert.Throws<InvalidOperationException>(() => IdentityBuilders.BuildPrincipal()
                .WithName("FalseName")
                .WithName(defaultName)
                .Create());
        }
    }
}
