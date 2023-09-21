using System.Security.Claims;

namespace BookStore.Api.Extensions;

public static class ClaimsPrincipalExtension
{
    public static string Id(this ClaimsPrincipal employee) 
        => employee.Claims.FirstOrDefault(x => x.Type == "Id")?.Value ?? string.Empty;
    public static string Name(this ClaimsPrincipal employee) 
        => employee.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value ?? string.Empty;
    public static string Email(this ClaimsPrincipal employee)
        => employee.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? string.Empty;
}
