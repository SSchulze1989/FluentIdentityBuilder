using FluentIdentityBuilder;
using System.Linq;
using System.Security.Claims;
using Xunit;

namespace UnitTests;

public class TestBuildPrincipal
{
    private const string defaultName = "Principal";
    private const string defaultId = "Identifier";
    private const string defaultAuthenticationType = "TestAuthentication";
    private const string defaultAuthenticationValue = "Authentication";
    private readonly Claim defaultClaim1 = new(ClaimTypes.Email, "Email");
    private readonly Claim defaultClaim2 = new(ClaimTypes.Uri, "www.principal.com");
    private const string defaultRole1 = "Role1";
    private const string defaultRole2 = "Role2";

    [Fact]
    public void BuildWithName()
    {
        var principal = StaticIdentityBuilders.BuildPrincipal()
            .WithName(defaultName)
            .Create();
        Assert.Equal(defaultName, principal.Identity.Name);
    }

    [Fact]
    public void BuildWithIdentifier()
    {
        var principal = StaticIdentityBuilders.BuildPrincipal()
            .WithIdentifier(defaultId)
            .Create();
        Assert.True(principal.HasClaim(ClaimTypes.NameIdentifier, defaultId));
    }

    [Fact]
    public void BuildWithClaims()
    {
        var principal = StaticIdentityBuilders.BuildPrincipal()
            .WithClaim(defaultClaim1.Type, defaultClaim1.Value)
            .WithClaim(defaultClaim2.Type, defaultClaim2.Value)
            .Create();
        Assert.True(principal.HasClaim(defaultClaim1.Type, defaultClaim1.Value));
        Assert.True(principal.HasClaim(defaultClaim2.Type, defaultClaim2.Value));
    }

    [Fact]
    public void BuildWithRoles()
    {
        var principal = StaticIdentityBuilders.BuildPrincipal()
            .WithRole(defaultRole1)
            .WithRole(defaultRole2)
            .Create();
        Assert.True(principal.IsInRole(defaultRole1));
        Assert.True(principal.IsInRole(defaultRole2));
    }

    [Fact]
    public void BuildWithAuthentication()
    {
        var principal = StaticIdentityBuilders.BuildPrincipal()
            .WithAuthentication(defaultAuthenticationType, defaultAuthenticationValue)
            .Create();
        Assert.True(principal.Identity.IsAuthenticated);
        Assert.True(principal.HasClaim(ClaimTypes.Authentication, defaultAuthenticationValue));
    }

    [Fact]
    public void OverrideName()
    {
        var principal = StaticIdentityBuilders.BuildPrincipal()
            .WithName("FalseName")
            .WithName(defaultName)
            .Create();
        Assert.Equal(defaultName, principal.Identity.Name);
    }

    [Fact]
    public void OverrideIdentifier()
    {
        var principal = StaticIdentityBuilders.BuildPrincipal()
            .WithIdentifier("FalseId")
            .WithIdentifier(defaultId)
            .Create();
        var identifier = principal.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        Assert.Equal(defaultId, identifier.Value);
    }

    [Fact]
    public void BuildWithDefaultName()
    {
        var builder = new ClaimsPrincipalBuilder();
        builder.Defaults.Name = defaultName;
        var principal = builder.Create();
        Assert.Equal(defaultName, principal.Identity.Name);
    }

    [Fact]
    public void BuildWithDefaultIdentfier()
    {
        var builder = new ClaimsPrincipalBuilder();
        builder.Defaults.Identifier = defaultId;
        var principal = builder.Create();
        Assert.True(principal.HasClaim(ClaimTypes.NameIdentifier, defaultId));
    }

    [Fact]
    public void BuildWithDefaultClaims()
    {
        var builder = new ClaimsPrincipalBuilder();
        builder.Defaults.Claims =
        [
            defaultClaim1,
            defaultClaim2
        ];
        var principal = builder.Create();
        Assert.True(principal.HasClaim(defaultClaim1.Type, defaultClaim1.Value));
        Assert.True(principal.HasClaim(defaultClaim2.Type, defaultClaim2.Value));
    }
}
