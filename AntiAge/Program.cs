
using AntiAge;
using AntiAge.Api.Data;
using AntiAge.Data;
using AntiAge.Data.Identity;
using AntiAge.Utility;
using AuthTest.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml;

var builder = WebApplication.CreateBuilder(args);


// Acquire password from environment variables
var connectionString = builder.Configuration.GetConnectionString("LocalSqlConnection");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? 
    throw new InvalidOperationException("Environment variable DB_PASSWORD is not set.");
connectionString = connectionString!.Replace("{DB_PASSWORD}", password);



// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var serviceConfig = ServiceConfigurationExtensions.ServiceConfig.Bearer;
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("https://localhost:7012")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AntiAgeContext>()
    .AddApiEndpoints()
    .AddDefaultTokenProviders();


builder.Services.AddDbContext<AntiAgeContext>(options =>
    //options.UseNpgsql(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure(1)), 
    options.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure(1))
);

builder.Services.AddScoped<DataImporter>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();
app.UseCors("AllowLocalhost");
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

