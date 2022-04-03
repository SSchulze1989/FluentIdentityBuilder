## Fluent API for building Identities
Api for creating System.Security.Claims instances like ClaimsPrincipal or ClaimsIdentity.
Can be used for UnitTesting - e.g: together with ASP NET Core

## Usage
Build a principal with name and role for unit testing purposes:
```csharp
var principal = IdentityBuilders.BuildPrincipal()
    .WithName("UserName")
    .WithRole("RoleName")
    .Create();
```
