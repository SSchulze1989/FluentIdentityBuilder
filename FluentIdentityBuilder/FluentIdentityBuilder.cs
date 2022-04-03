using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FluentIdentityBuilder
{
    internal class FluentIdentityBuilder : FluentIdentityBuilderBase<ClaimsIdentity>, IIdentityBuilder<ClaimsIdentity>
    {
        public FluentIdentityBuilder() : base() { }

        public FluentIdentityBuilder(IEnumerable<Claim> claims) : base(claims) { }

        protected override ClaimsIdentity Create()
        {
            return new ClaimsIdentity(claims, authenticationType);
        }

    }
}
