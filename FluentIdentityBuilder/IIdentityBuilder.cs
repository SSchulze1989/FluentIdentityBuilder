namespace FluentIdentityBuilder;

public interface IIdentityBuilder<T>
{
    IIdentityBuilder<T> WithName(string name);
    IIdentityBuilder<T> WithIdentifier(string identifier);
    IIdentityBuilder<T> WithClaim(string type, string value);
    IIdentityBuilder<T> WithRole(string role);
    IIdentityBuilder<T> WithAuthentication(string authenticationType, string authenticationValue);
    T Create();
}
