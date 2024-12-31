using System.Security.Claims;

namespace FluentIdentityBuilder;

public static class StaticIdentityBuilders
{
    public static IIdentityBuilder<ClaimsIdentity> BuildIdentity()
    {
        return new FluentIdentityBuilder();
    }

    public static IIdentityBuilder<ClaimsPrincipal> BuildPrincipal()
    {
        return new FluentPrincipalBuilder();
    }
}
