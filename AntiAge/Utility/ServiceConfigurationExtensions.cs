using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace AuthTest.Utility
{
    public static class ServiceConfigurationExtensions
    {
        public enum ServiceConfig
        {
            Cookie = 0,
            Bearer = 1,
        }

        public static void ConfigureAuthentication(this IServiceCollection services, ServiceConfig configuration)
        {
            if (configuration == ServiceConfig.Cookie)
            {
                services.AddAuthentication(options =>
                {
                    // Default scheme is set to Cookie
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;  // Optional: Set fallback for 401s
                })
                .AddCookie(IdentityConstants.ApplicationScheme, options =>
                {
                    options.LoginPath = "/login";  // Path to redirect for login
                    options.Cookie.Name = ".AspNetCore.Cookies";  // Cookie name
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SameSite = SameSiteMode.Lax;  // Cookie settings
                });
            }
            else if (configuration == ServiceConfig.Bearer)
            {

                services.AddAuthentication(options =>
                    {
                        options.DefaultScheme = IdentityConstants.BearerScheme;
                        options.DefaultChallengeScheme = IdentityConstants.BearerScheme;
                    })
                    .AddBearerToken(IdentityConstants.BearerScheme);
            }
        }

        public static void ConfigureAuthorization(this IServiceCollection services, ServiceConfig configuration)
        {
            if (configuration == ServiceConfig.Cookie)
            {
                services.AddAuthorization(options =>
                {
                    var policy = new AuthorizationPolicyBuilder(IdentityConstants.ApplicationScheme) // Use Cookie-only scheme
                        .RequireAuthenticatedUser()
                        .Build();
                    options.DefaultPolicy = policy;
                });
            }

            else if (configuration == ServiceConfig.Bearer)
            {
                services.AddAuthorization(options =>
                {
                    var policy = new AuthorizationPolicyBuilder(IdentityConstants.BearerScheme)
                        .RequireAuthenticatedUser()
                        .Build();
                    options.DefaultPolicy = policy;
                });
            }
        }

        public static void ConfigureSwagger(this IServiceCollection services, ServiceConfig configuration)
        {
            if (configuration == ServiceConfig.Cookie)
            {
                services.AddSwaggerGen(c =>
                {
                    c.AddSecurityDefinition("Cookie", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Cookie,
                        Description = "Authentication via cookie",
                        Name = ".AspNetCore.Cookies",
                        Type = SecuritySchemeType.ApiKey
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Cookie" }
                            },
                            Array.Empty<string>()
                        }
                    });
                });
            }
            else if (configuration == ServiceConfig.Bearer)
            {
                services.AddSwaggerGen(c =>
                {
                    // Define Bearer token in Swagger
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Enter your Bearer token in the format 'Bearer {token}'",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT" // Optional, but adds clarity for Swagger UI
                    });

                    // Add Security Requirement to all API calls
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement{{
                            new OpenApiSecurityScheme
                            { Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,Id = "Bearer"}},new string[] { }
                            }
                    });
                });
            }

        }
    }
}
