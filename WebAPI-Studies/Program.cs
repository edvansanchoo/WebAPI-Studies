using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPI_Studies;
using WebAPI_Studies.api.Infrastructure;
using WebAPI_Studies.api.Infrastructure.Repositories;
using WebAPI_Studies.api.Application.Services;
using WebAPI_Studies.api.Domain.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//var dbHost = "192.168.100.89";
//var database = "webapi";
//var user = "sa";
//var password = "Pass@word";

var dbHost = Environment.GetEnvironmentVariable("DBHOST");
var database = Environment.GetEnvironmentVariable("DATABASE");
var user = Environment.GetEnvironmentVariable("USER");
var password = Environment.GetEnvironmentVariable("PASSWORD");

//var connectionString = $"Data Source={dbHost}; Initial Catalog={database}; User ID={user}; Password={password}";
var connectionString = $"Server={dbHost}; Database={database}; User Id={user}; Password={password}; Trusted_Connection=False; Encrypt=false; TrustServerCertificate=True";

builder.Services.AddDbContext<ConnectionContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    { 
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddScoped<ConnectionContext>();
builder.Services.AddScoped<TokenService>();

var key = Encoding.ASCII.GetBytes(Key.GetSecret());

builder.Services.AddAuthentication(x => 
{ 
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => 
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DatabaseManagementService.MigrationInicialization(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
