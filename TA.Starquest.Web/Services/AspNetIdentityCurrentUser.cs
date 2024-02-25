using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TA.Starquest.DataAccess.Identity;

namespace TA.Starquest.Web.Services;

/// <summary>
///     Encapsulates the concept of a 'current user' based on ASP.Net Identity.
/// </summary>
/// <seealso cref="ICurrentUser" />
public class AspNetIdentityCurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AspNetIdentityCurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string DisplayName => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
    public string LoginName => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    public string UniqueId => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Sid)?.Value;
    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
}
