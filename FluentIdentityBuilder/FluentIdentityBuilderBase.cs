using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FluentIdentityBuilder
{
    internal abstract class FluentIdentityBuilderBase<T> : IIdentityBuilder<T>
    {
        protected string? authenticationType = null;
        protected readonly List<Claim> claims;

        public FluentIdentityBuilderBase()
        {
            claims = new List<Claim>();
        }

        public FluentIdentityBuilderBase(IEnumerable<Claim> claims)
        {
            this.claims = claims.ToList();
        }

        protected abstract T Create();

        T IIdentityBuilder<T>.Create()
        {
            return Create();
        }

        private void AddOrUpdateClaim(string claimType, string value)
        {
            if (claims.Any(x => x.Type == claimType && x.Value == value))
            {
                claims.Remove(claims.Single(x => x.Type == claimType && x.Value == value));
            }
            claims.Add(new Claim(claimType, value));
        }

        IIdentityBuilder<T> IIdentityBuilder<T>.WithClaim(string type, string value)
        {
            AddOrUpdateClaim(type, value);
            return this;
        }

        IIdentityBuilder<T> IIdentityBuilder<T>.WithIdentifier(string identifier)
        {
            claims.RemoveAll(x => x.Type == ClaimTypes.NameIdentifier);
            AddOrUpdateClaim(ClaimTypes.NameIdentifier, identifier);
            return this;
        }

        IIdentityBuilder<T> IIdentityBuilder<T>.WithName(string name)
        {
            claims.RemoveAll(x => x.Type == ClaimTypes.Name);
            AddOrUpdateClaim(ClaimTypes.Name, name);
            return this;
        }

        IIdentityBuilder<T> IIdentityBuilder<T>.WithRole(string role)
        {
            AddOrUpdateClaim(ClaimTypes.Role, role);
            return this;
        }

        IIdentityBuilder<T> IIdentityBuilder<T>.WithAuthentication(string authenticationType, string authenticationValue)
        {
            this.authenticationType = authenticationType;
            AddOrUpdateClaim(ClaimTypes.Authentication, authenticationValue);
            return this;
        }
    }
}
