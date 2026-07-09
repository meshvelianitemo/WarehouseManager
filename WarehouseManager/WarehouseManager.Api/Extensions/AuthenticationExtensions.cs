using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace WarehouseManager.Api.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                     {
                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidIssuer = configuration["JwtSettings:ValidIssuer"],
                             ValidAudience = configuration["JwtSettings:ValidAudience"],
                             IssuerSigningKey = new SymmetricSecurityKey(
                                 Encoding.UTF8.GetBytes(
                                     configuration["JwtSettings:Key"]
                                         ?? throw new InvalidOperationException("JWT Key not configured"))),
                             ValidateIssuer = true,
                             ValidateAudience = true,
                             ValidateLifetime = true,
                             ValidateIssuerSigningKey = true,
                             RoleClaimType = ClaimTypes.Role
                         };
                     });

            return services;
        }
    }
}
