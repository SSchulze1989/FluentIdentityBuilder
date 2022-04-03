using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FluentIdentityBuilder
{
    public static class IdentityBuilders
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
}
