using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FluentIdentityBuilder
{
    public class ClaimsIdentityBuilder
    {
        public IdentityDefaults Defaults { get; }

        public ClaimsIdentityBuilder()
        {
            Defaults = new IdentityDefaults();
        }

        public ClaimsIdentityBuilder(IdentityDefaults defaults)
        {
            Defaults = defaults;
        }

        /// <summary>
        /// Start the fluent builder with the configured defaults
        /// </summary>
        /// <returns></returns>
        public IIdentityBuilder<ClaimsIdentity> StartBuild()
        {
            // set defaults
            IIdentityBuilder<ClaimsIdentity> builder = new FluentIdentityBuilder(Defaults.Claims);
            if (string.IsNullOrEmpty(Defaults.Identifier) == false)
            {
                builder.WithIdentifier(Defaults.Identifier);
            }
            if (string.IsNullOrEmpty(Defaults.Name) == false)
            {
                builder.WithName(Defaults.Name);
            }
            return builder;
        }

        /// <summary>
        /// Create identity with the configured defaults
        /// </summary>
        /// <returns></returns>
        public ClaimsIdentity Create()
        {
            return StartBuild().Create();
        }
    }
}
