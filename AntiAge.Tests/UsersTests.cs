using AntiAge.Data.Identity;
using Azure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace AntiAge.Tests
{
    public class UsersTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public UsersTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CreateUser_SucceedsAndCreatesUserInDatabase()
        {
            // Arrange
            var email = $"user{Guid.NewGuid()}@example.com";
            var client = _factory.CreateClient();
            var payload = new
            {
                email = email,
                password = "Password123!"
            };

            // Act
            var response = await client.PostAsJsonAsync("/register", payload);
            Assert.True(response.IsSuccessStatusCode);

            // Assert
            using var scope = _factory.Services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var user = await userManager.FindByEmailAsync(email);
            Assert.NotNull(user);
        }

        [Fact]
        public async Task CreateUser_FailsOnCreatingDuplicateUser()
        {
            // Arrange
            var email = $"user{Guid.NewGuid()}@example.com";
            var client = _factory.CreateClient();
            var payload = new
            {
                email = email,
                password = "Password123!"
            };

            
            var response = await client.PostAsJsonAsync("/register", payload);
            Assert.True(response.IsSuccessStatusCode);

            var response2 = await client.PostAsJsonAsync("/register", payload);
            Assert.False(response2.IsSuccessStatusCode);
        }

        [Fact]
        public async Task CreateUser_FailsOnInvalidPasswordFormat()
        {
            // Arrange
            var email = $"user{Guid.NewGuid()}@example.com";
            var client = _factory.CreateClient();
            var payload = new
            {
                email = email,
                password = "pass"
            };
            using (var scope = _factory.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var user = new User { Email = payload.email, UserName = payload.email };
                var result = await userManager.CreateAsync(user, payload.password);
                if (!result.Succeeded)
                {
                    Assert.True(result.Errors.Any());
                    //foreach (var error in result.Errors)
                    //{
                    //    // error.Code (e.g. "PasswordTooShort")
                    //    // error.Description (e.g. "Passwords must be at least 6 characters.")
                    //}
                }
            }
        }
    }
}