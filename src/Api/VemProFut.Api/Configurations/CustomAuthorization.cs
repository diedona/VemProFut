using System.Security.Claims;
using VemProFut.Domain.Authentication.Constants;

namespace VemProFut.Api.Configurations
{
    public static class CustomAuthorization
    {
        public static void AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorizationBuilder()
                .AddPolicy(PoliciesConsts.AdminPolicyName, policy =>
                    policy.RequireClaim(claimType: ClaimTypes.Role, UserRolesConsts.AdminRole)
                ).AddPolicy(PoliciesConsts.ReaderPolicyName, policy =>
                    policy.RequireClaim(claimType: ClaimTypes.Role, UserRolesConsts.ReaderRole, UserRolesConsts.AdminRole)
                ).AddPolicy(PoliciesConsts.WriterPolicyName, policy =>
                    policy.RequireClaim(claimType: ClaimTypes.Role, UserRolesConsts.WriterRole, UserRolesConsts.AdminRole)
                );
        }
    }
}
