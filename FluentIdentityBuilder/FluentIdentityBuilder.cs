using System.Collections.Generic;
using System.Security.Claims;

namespace FluentIdentityBuilder;

internal class FluentIdentityBuilder : FluentIdentityBuilderBase<ClaimsIdentity>, IIdentityBuilder<ClaimsIdentity>
{
    public FluentIdentityBuilder() : base() { }

    public FluentIdentityBuilder(IEnumerable<Claim> claims) : base(claims) { }

    protected override ClaimsIdentity Create()
    {
        return new ClaimsIdentity(claims, authenticationType);
    }

}
