using HeadlessCMS.Service;
using HeadlessCMS.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Add(ServiceDescriptor.Transient<IWebsiteService, WebsiteService>());//to activate
builder.Services.Add(ServiceDescriptor.Transient<IWebsiteRepository, WebsiteRepository>());//to activate

builder.Services.Add(ServiceDescriptor.Transient<IContentService, ContentService>());//to activate
builder.Services.Add(ServiceDescriptor.Transient<IContentRepository, ContentRepository>());//to activate

builder.Services.Add(ServiceDescriptor.Transient<IComponentsService, ComponentsService>());//to activate
builder.Services.Add(ServiceDescriptor.Transient<IComponentsRepository, ComponentsRepository>());//to activate

builder.Services.Add(ServiceDescriptor.Transient<IPageService, PageService>());//to activate
builder.Services.Add(ServiceDescriptor.Transient<IPageRepository, PageRepository>());//to activate

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard authheader using Bearer schemes (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        //BearerFormat = "JWT",
        //Scheme = "Bearer"
    });
    option.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddDbContext<CmsDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnectionString")));

var app = builder.Build();



// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
