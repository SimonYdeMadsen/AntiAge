using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Data.Entities;
using WebApplication1.Extensions;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);


builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AntiAgeContext>()
    .AddApiEndpoints(); // Adds the necessary API endpoints for Identity

//https://youtu.be/S0RSsHKiD6Y?t=409

builder.Services.AddDbContext<AntiAgeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlConnection"))  //Azure = "DefaultConnection1"
);




var app = builder.Build();
// Ensure the database schema is created (no migrations)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AntiAgeContext>();
    context.Database.EnsureCreated();  // This will ensure the database is created without migrations
}

//if (app.Environment.IsDevelopment())
//{
//    app.ApplyMigrations();
//}

// Enables Swagger UI
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    options.RoutePrefix = string.Empty; // Optional: Makes Swagger UI accessible at root
});

app.UseHttpsRedirection();




app.MapControllers();
app.MapIdentityApi<User>();


app.Run();