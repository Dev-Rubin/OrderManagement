using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OrderManagement.Application;
using OrderManagement.Logic;
using OrderManagement.Microservice;
using OrderManagement.Microservice.Middlewares;
using OrderManagement.Persistence;
using OrderManagement.Infrastructure;
using Scalar.AspNetCore;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Serilog Configuration
// Setup Serilog from appsettings.json
builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration)
    .Enrich.FromLogContext()
);
#endregion

#region Services Registration

// Add Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// HTTP Context Accessor
builder.Services.AddHttpContextAccessor();

// Custom services
builder.Services.AddMapper();
builder.Services.AddLogic(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
#endregion



#region Authentication & Authorization

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            ),
            ClockSkew = TimeSpan.Zero // optional: no extra expiration time
        };
    });


#endregion


#region CORS Configuration

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

#endregion

var app = builder.Build();

#region Apply Pending Migrations

//Ensure DB is up-to-date
await app.ApplyPendingMigrationsAsync();

#endregion


#region Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();           // /openapi/v1.json
    app.MapScalarApiReference(); // /scalar
}

// HTTPS redirection
app.UseHttpsRedirection();
// Routing
app.UseRouting();

app.UseCors("AllowFrontend");
// Global Exception Handling
app.UseMiddleware<GlobalExceptionMiddleware>();
// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();
// User Context Middleware (after authentication)
app.UseMiddleware<UserContextMiddleware>();
app.MapControllers();

#endregion

app.Run();


