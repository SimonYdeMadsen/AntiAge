using AntiAge.Data;
using AntiAge.Data.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiAge.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(IPasswordValidator<>));
                // Remove default Identity stores if needed
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IUserStore<IdentityUser>));
                if (descriptor != null) services.Remove(descriptor);

                // Add in-memory Identity stores
                services.AddIdentityCore<User>()
                    .AddRoles<IdentityRole<int>>()
                    .AddEntityFrameworkStores<InMemoryDbContext>()
                    .AddApiEndpoints()
                    .AddDefaultTokenProviders();

                services.Replace(ServiceDescriptor.Scoped<IPasswordValidator<User>, CustomPasswordValidator<User>>());

                // Configure in-memory DB for Identity
                services.AddDbContext<InMemoryDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb"));

                // Configure authentication to use test scheme
                services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
            });
        }
    }
}
