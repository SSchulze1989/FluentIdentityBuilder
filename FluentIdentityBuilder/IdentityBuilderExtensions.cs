using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FluentIdentityBuilder
{
    public static class IdentityBuilderExtensions
    {
        public static IIdentityBuilder<T> WithClaims<T>(this IIdentityBuilder<T> builder, IEnumerable<Claim> claims)
        {
            foreach(var claim in claims)
            {
                builder.WithClaim(claim.Type, claim.Value);
            }
            return builder;
        }

        public static IIdentityBuilder<T> WithRoles<T>(this IIdentityBuilder<T> builder, IEnumerable<string> roles)
        {
            foreach(var role in roles)
            {
                builder.WithRole(role);
            }
            return builder;
        }
    }
}
