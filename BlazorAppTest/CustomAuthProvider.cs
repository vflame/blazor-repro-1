using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using System.Security.Claims;

public class CustomAuthProvider : ServerAuthenticationStateProvider
{
    public readonly static ClaimsPrincipal GuestClaims = new ClaimsPrincipal(new ClaimsIdentity("123"));

    public readonly static AuthenticationState GuestAuthenticationState = new AuthenticationState(GuestClaims);
    public readonly static Task<AuthenticationState> GuestAuthenticationStateTask = Task.FromResult(GuestAuthenticationState);

    public string Id = Guid.NewGuid().ToString();

    public CustomAuthProvider()
    {
        SetAuthenticationState(GuestAuthenticationStateTask);
    }
}