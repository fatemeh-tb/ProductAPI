using System.Security.Claims;
using System.Security.Principal;

namespace ProductShop.Extentions;

public static class IdentityExtentions
{
	public static string GetOrganizationId(this IIdentity identity)
	{
		var claim = ((ClaimsIdentity)identity).FindFirst("Name");
		// Test for null to avoid issues during local testing
		return (claim != null) ? claim.Value : string.Empty;
	}
}