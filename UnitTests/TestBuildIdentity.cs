using FluentIdentityBuilder;
using System;
using System.Linq;
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
            var identity = StaticIdentityBuilders.BuildIdentity()
                .WithName(defaultName)
                .Create();
            Assert.Equal(identity.Name, defaultName);
        }

        [Fact]
        public void BuildWithIdentifier()
        {
            var identity = StaticIdentityBuilders.BuildIdentity()
                .WithIdentifier(defaultId)
                .Create();
            Assert.True(identity.HasClaim(ClaimTypes.NameIdentifier, defaultId));
        }

        [Fact]
        public void BuildWithClaims()
        {
            var identity = StaticIdentityBuilders.BuildIdentity()
                .WithClaim(defaultClaim1.Type, defaultClaim1.Value)
                .WithClaim(defaultClaim2.Type, defaultClaim2.Value)
                .Create();
            Assert.True(identity.HasClaim(defaultClaim1.Type, defaultClaim1.Value));
            Assert.True(identity.HasClaim(defaultClaim2.Type, defaultClaim2.Value));
        }

        [Fact]
        public void BuildWithRoles()
        {
            var identity = StaticIdentityBuilders.BuildIdentity()
                .WithRole(defaultRole1)
                .WithRole(defaultRole2)
                .Create();
            Assert.Contains(identity.Claims, x => x.Type == ClaimTypes.Role && x.Value == defaultRole1);
            Assert.Contains(identity.Claims, x => x.Type == ClaimTypes.Role && x.Value == defaultRole2);
        }

        [Fact]
        public void BuildWithAuthentication()
        {
            var identity = StaticIdentityBuilders.BuildIdentity()
                .WithAuthentication(defaultAuthenticationType, defaultAuthenticationValue)
                .Create();
            Assert.True(identity.IsAuthenticated);
            Assert.True(identity.HasClaim(ClaimTypes.Authentication, defaultAuthenticationValue));
        }

        [Fact]
        public void OverrideName()
        {
            var identity = StaticIdentityBuilders.BuildIdentity()
                .WithName("FalseName")
                .WithName(defaultName)
                .Create();
            Assert.Equal(defaultName, identity.Name);
        }

        [Fact]
        public void OverrideIdentifier()
        {
            var identity = StaticIdentityBuilders.BuildIdentity()
                .WithIdentifier("FalseId")
                .WithIdentifier(defaultId)
                .Create();
            var identifier = identity.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            Assert.Equal(defaultId, identifier.Value);
        }

        [Fact]
        public void BuildWithDefaultName()
        {
            var builder = new ClaimsIdentityBuilder();
            builder.Defaults.Name = defaultName;
            var identity = builder.Create();
            Assert.Equal(defaultName, identity.Name);
        }

        [Fact]
        public void BuildWithDefaultIdentfier()
        {
            var builder = new ClaimsIdentityBuilder();
            builder.Defaults.Identifier = defaultId;
            var identity = builder.Create();
            Assert.True(identity.HasClaim(ClaimTypes.NameIdentifier, defaultId));
        }

        [Fact]
        public void BuildWithDefaultClaims()
        {
            var builder = new ClaimsIdentityBuilder();
            builder.Defaults.Claims = new Claim[]
            {
                defaultClaim1,
                defaultClaim2
            };
            var identity = builder.Create();
            Assert.True(identity.HasClaim(defaultClaim1.Type, defaultClaim1.Value));
            Assert.True(identity.HasClaim(defaultClaim2.Type, defaultClaim2.Value));
        }
    }
}
