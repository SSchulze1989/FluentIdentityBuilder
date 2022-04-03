using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FluentIdentityBuilder
{
    internal class FluentPrincipalBuilder : FluentIdentityBuilderBase<ClaimsPrincipal>, IIdentityBuilder<ClaimsPrincipal>
    {
        public FluentPrincipalBuilder()
        {
        }

        public FluentPrincipalBuilder(IEnumerable<Claim> claims) : base(claims)
        {
        }

        protected override ClaimsPrincipal Create()
        {
            return new ClaimsPrincipal(new ClaimsIdentity(claims, authenticationType));
        }
    }
}
