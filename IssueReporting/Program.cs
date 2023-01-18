using IssueReporting.DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApiTemplate.Api.Authentication;
using WebApiTemplate.DataAccess.Infrastructure;
using WebApiTemplate.Domain.Infrastructure;
using WebApiTemplate.Domain.Middleware;
using WebApiTemplate.Services.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IssueReportingContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
ServiceBindings.Register(builder.Services);
RepositoryBindings.Register(builder.Services);
DomainBindings.Register(builder.Services);
RepositoryBindings.Register(builder.Services);
Authentication.Authenticate(builder);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

SwaggerConfiguration(builder);

var app = builder.Build();

app.UseCors(options =>
options.WithOrigins("http://localhost:3000")
.AllowAnyMethod()
.AllowAnyHeader());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.ConfigureExceptionHandler(logger);
app.ConfigureCustomExceptionMiddleware();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void SwaggerConfiguration(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Issue Reporting", Version = "v1" });
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    });
}