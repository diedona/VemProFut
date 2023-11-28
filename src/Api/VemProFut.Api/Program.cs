using Carter;
using Serilog;
using VemProFut.Api.Configurations;
using VemProFut.Api.Configurations.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddThirdPartyServices();
builder.Services.AddCustomExceptionHandlers();
builder.Services.AddCustomOptions(builder);
builder.Services.AddDomainServices();
builder.Services.AddCustomAuthentication(builder);
builder.Services.AddCustomAuthorization();
builder.Services.AddCors();

builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCarter();

app.UseSerilogRequestLogging();
app.UseExceptionHandler(_ => { }); // discard lambda due to a bug in .net 8 as of 2023/11/26
app.UseAuthentication();
app.UseAuthorization();
app.UseCustomCors(builder);

app.Run();