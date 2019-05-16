using System.Linq;
using System.Security.Claims;

namespace BaseApiArchitecture.Utils
{
	public static class ClaimsPrincipalExtensions
	{
		public static string GetClaim(this ClaimsPrincipal Principal, string Key)
		{
			return Principal?.Claims?.FirstOrDefault(x => x.Type.EqualsNormalized(Key))?.Value;
		}
	}
}
