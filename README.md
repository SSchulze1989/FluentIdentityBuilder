## Fluent API for building Identities
Api for creating System.Security.Claims instances like ClaimsPrincipal or ClaimsIdentity.
Can be used for UnitTesting - e.g: together with ASP NET Core

## Supported Types
- ClaimsIdentity
- ClaimsPrincipal

## Usage
Build an identity or principal for unit testing purposes:
```csharp
ClaimsIdentity identity = IdentityBuilders.BuildIdentity()
    .WithName("UserName")
    .WithClaim("ClaimType", "ClaimValue")
    .Create();
```

```csharp
ClaimsPrincipal principal = IdentityBuilders.BuildPrincipal()
    .WithName("UserName")
    .WithRole("RoleName")
    .Create();
```
