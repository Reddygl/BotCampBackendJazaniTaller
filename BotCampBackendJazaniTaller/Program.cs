using Autofac;
using Autofac.Extensions.DependencyInjection;
using BotCampBackendJazaniTaller.Filters;
using BotCampBackendJazaniTaller.Middlewares;
using FluentValidation.AspNetCore;
using Jazani.Application.Cores.Contexts;
using Jazani.Infraestructura.Cores.Contexts;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.File(
        ".." + Path.DirectorySeparatorChar + "logapi.log",
        LogEventLevel.Error
    )
    .CreateLogger();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilters());
});

// Route Options
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;

});

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.addInfrastructureServices(builder.Configuration);

builder.Services.AddApplicationServices();

//Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfraestructuraAutofacModule());
        options.RegisterModule(new ApplicationAutofacModule());
    });

builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
