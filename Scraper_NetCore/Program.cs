using Microsoft.EntityFrameworkCore;
using Scraper_NetCore.Data;
using Scraper_NetCore.Repositories.Classes;
using Scraper_NetCore.Repositories.Interfaces;
using Scraper_NetCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* DATABASE */
builder.Services.AddDbContext<DBMainContext>(options =>
{
    var mainConnectionString = builder.Configuration.GetConnectionString("DBConnection");
    if (mainConnectionString != null)
    {
        options.UseSqlServer(mainConnectionString);
    }
    else
    {
        Console.WriteLine("ERROR: Unable to connect to server!");
    }
});


builder.Services.AddScoped<IScraper, Scraper>();

builder.Services.AddScoped<ICompanyCreate, CompanyCreate>();
builder.Services.AddScoped<ICompanyGet, CompanyGet>();

builder.Services.AddScoped<ICompanyItemsCreate, CompanyItemsCreate>();
builder.Services.AddScoped<ICompanyItemsGet, CompanyItemsGet>();


builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
