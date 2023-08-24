using POS.Application.Extensions;
using POS.Infrastructure.Extensions;
using POS.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Add services to the container.


//cors
var Cors = "Cors";



//inyecciones propias
builder.Services.AddInjectionInfraestructure(Configuration);
builder.Services.AddInjectionApplication(Configuration);
builder.Services.AddAuthentication(Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(); generado por defecto en todo programa aspnet
builder.Services.AddSwagger();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors(Cors);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
//dotnet ef dbcontext scaffold "Server=(local); DataBase=POS; Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Entities

public partial class Program { }