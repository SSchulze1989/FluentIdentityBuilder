﻿using System.Security.Claims;

namespace FluentIdentityBuilder;

public class ClaimsPrincipalBuilder
{
    public IdentityDefaults Defaults { get; }

    public ClaimsPrincipalBuilder() 
    {
        Defaults = new IdentityDefaults();
    }
    public ClaimsPrincipalBuilder(IdentityDefaults defaults)
    {
        Defaults = defaults;
    }

    public IIdentityBuilder<ClaimsPrincipal> StartBuild()
    {
        IIdentityBuilder<ClaimsPrincipal> builder = new FluentPrincipalBuilder(Defaults.Claims);
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

    public ClaimsPrincipal Create()
    {
        return StartBuild().Create();
    }
}
