
using AntiAge;
using AntiAge.Data;
using AntiAge.Data.Identity;
using AntiAge.Utility;
using AuthTest.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Supabase;
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

//builder.Services.AddScoped<Supabase.Client>(_ =>
//    new Supabase.Client(
//        builder.Configuration["SupabaseUrl"],
//        builder.Configuration["SupabaseKey"],
//        new SupabaseOptions()
//        {
//            AutoRefreshToken = true,
//            AutoConnectRealtime = true
//        }
//        ));

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



builder.Services.AddDbContext<AntiAgeContext>(options =>
    //options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDb"), 
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineConnection"),
    sqlOptions => sqlOptions.EnableRetryOnFailure(1)
));

builder.Services.AddScoped<DataImporter>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.ApplyMigrations();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();
    await SeedRoles.Initialize(services, userManager, roleManager);

    services.GetService<DataImporter>()!.ImportDummyData();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger", permanent: false);
    return Task.CompletedTask;
});
app.MapControllers();
app.MapIdentityApi<User>();

app.Run();

