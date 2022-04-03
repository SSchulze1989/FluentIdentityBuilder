using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FluentIdentityBuilder
{
    public interface IIdentityBuilder<T>
    {
        IIdentityBuilder<T> WithName(string name);
        IIdentityBuilder<T> WithIdentifier(string identifier);
        IIdentityBuilder<T> WithClaim(string type, string value);
        IIdentityBuilder<T> WithRole(string role);
        IIdentityBuilder<T> WithAuthentication(string authenticationType, string authenticationValue);
        T Create();
    }
}
