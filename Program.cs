using HeadlessCMS.Service;
using HeadlessCMS.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;


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
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CmsDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
