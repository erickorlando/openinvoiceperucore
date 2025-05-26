using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Servicio;
using OpenInvoicePeru.Servicio.Soap;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICertificador, Certificador>();
builder.Services.AddTransient<ISerializador, Serializador>();
builder.Services.AddTransient<IValidezComprobanteHelper, ValidezComprobanteHelper>();

builder.Services.AddScoped<IServicioSunatDocumentos, ServicioSunatDocumentos>();
builder.Services.AddScoped<IServicioSunatConsultas, ServicioSunatConsultas>();

const string corsConfiguration = "OpenInvoicePeru";

builder.Services.AddCors(setup =>
{
    setup.AddPolicy(corsConfiguration, policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        // options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        // options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OpenInvoicePeru API REST NET 9", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenInvoicePeru.WebApi v1"));
}
else
{
    // In production, you might want to configure a different Swagger UI endpoint or leave it out.
    // For this example, we'll keep it similar to the original Startup.cs for non-development.
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "OpenInvoicePeru.WebApi v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors(corsConfiguration);

app.MapControllers();

app.Run();
