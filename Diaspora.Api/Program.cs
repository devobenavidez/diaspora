// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Diaspora.Application;
using Diaspora.Domain.Abstractions;
using Diaspora.Domain.Services;
using Diaspora.Infrastructure.Data;
using Diaspora.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

/*builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8086);
});*/

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssembly).Assembly));

var environment = builder.Environment.EnvironmentName;

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

var databaseVersion = builder.Configuration.GetValue<string>("DatabaseVersion");

builder.Services.AddDbContext<DBContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DiasporaDatabase"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse(databaseVersion),
    options => options.MigrationsAssembly("Diaspora.Infrastructure")));

builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IHashingService, HashingService>();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1.0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();

});

var app = builder.Build();

// Configure the HTTP request pipeline. 6
if (app.Environment.IsEnvironment("Local") || app.Environment.IsEnvironment("Qa") || app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();