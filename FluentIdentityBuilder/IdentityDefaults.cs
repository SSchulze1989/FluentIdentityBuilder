using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace FluentIdentityBuilder;

public class IdentityDefaults
{
    public string Name { get; set; }
    public string Identifier { get; set; }
    public IEnumerable<Claim> Claims { get; set; }
    public IEnumerable<string> Roles => Claims
        .Where(x => x.Type == ClaimTypes.Role)
        .Select(x => x.Value);

    public IdentityDefaults()
    {
        Claims = [];
    }
}
