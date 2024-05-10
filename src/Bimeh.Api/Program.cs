using Bimeh.Domain.Coverages.Contratcs;
using Bimeh.Domain.Requests.Contracts;
using Bimeh.Persistance;
using Bimeh.Persistance.Coverages;
using Bimeh.Persistance.Requests;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cf =>
{
    var _assemblyNamesForLoad = "Bimeh";
    var listOfAssemblies = new List<Assembly>();

    foreach (var library in DependencyContext.Default.RuntimeLibraries)
    {
        if (library.Name.Contains(_assemblyNamesForLoad, StringComparison.OrdinalIgnoreCase))
        {
            var assembly = Assembly.Load(new AssemblyName(library.Name));
            listOfAssemblies.Add(assembly);
        }
    };

    cf.RegisterServicesFromAssemblies(listOfAssemblies.ToArray());
});

builder.Services.AddDbContext<BimehCommandDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IReqeustsQueryRepository, ReqeustsQueryRepository>();
builder.Services.AddScoped<IReqeustsCommandRepository, ReqeustsCommandRepository>();
builder.Services.AddScoped<ICoverageCommandRepository, CoverageCommandRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


