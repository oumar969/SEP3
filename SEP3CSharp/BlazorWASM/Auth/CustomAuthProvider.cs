using HttpClients.ClientInterfaces;

namespace BlazorWasm.Auth;

using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthProvider : AuthenticationStateProvider
{
    private readonly IAuthService authService;
    private readonly ILogger<CustomAuthProvider> logger;

    public CustomAuthProvider(IAuthService authService, ILogger<CustomAuthProvider> logger)
    {
        this.authService = authService;
        this.logger = logger;

        authService.OnAuthStateChanged += AuthStateChanged;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            ClaimsPrincipal principal = await authService.GetAuthAsync();

            // Log indholdet af AuthenticationState for fejlfinding
            logger.LogInformation("AuthenticationState: {0}", principal);

            return new AuthenticationState(principal);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Fejl under GetAuthenticationStateAsync");
            throw;
        }
    }

    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}
//
//     public CustomAuthProvider(IAuthService authService)
//     {
//         this.authService = authService;
//         authService.OnAuthStateChanged += AuthStateChanged;
//     }
//     
//     public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//     {
//         ClaimsPrincipal principal = await authService.GetAuthAsync();
//         
//         return new AuthenticationState(principal);
//     }
//     
//     private void AuthStateChanged(ClaimsPrincipal principal)
//     {
//         NotifyAuthenticationStateChanged(
//             Task.FromResult(
//                 new AuthenticationState(principal)
//             )
//         );
//     }
// }
