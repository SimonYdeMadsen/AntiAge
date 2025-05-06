
using AntiAge;
using AntiAge.Data;
using AntiAge.Data.Entities;
using AntiAge.Utility;
using AuthTest.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var serviceConfig = ServiceConfigurationExtensions.ServiceConfig.Cookie;
builder.Services.ConfigureAuthentication(serviceConfig);
builder.Services.ConfigureAuthorization(serviceConfig);
builder.Services.ConfigureSwagger(serviceConfig);

/*
{
"email": "admin@email.com",
"password": "Password123!"
}
*/

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AntiAgeContext>()
    .AddApiEndpoints()
    .AddDefaultTokenProviders();
                

//builder.Services.AddScoped<IRoleStore<IdentityRole>, RoleStore<IdentityRole, AntiAgeContext>>();
//builder.Services.AddScoped<IRoleStore<Role>, RoleStore<Role, AntiAgeContext, int>>();
            

builder.Services.AddDbContext<AntiAgeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineConnection"),
    sqlOptions => sqlOptions.EnableRetryOnFailure(1)
));

builder.Services.AddScoped<DataImporter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();

}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    //var userManager = services.GetRequiredService<UserManager<User>>();
    //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();
    //SeedRoles(services, userManager, roleManager).Wait();
    await SeedRoles.Initialize(services, userManager, roleManager);

    services.GetService<DataImporter>()!.ImportDummyData();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.MapIdentityApi<User>();

app.Run();

