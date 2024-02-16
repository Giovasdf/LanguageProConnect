using LanguageProConnect.Data;
using LanguageProConnect.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VendorsDbContext>(options => options.UseInMemoryDatabase("LanguageProConnectDB"));

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

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<VendorsDbContext>();
    SeedData(dbContext);
}

app.Run();

// Method to seed data
static void SeedData(VendorsDbContext dbContext)
{
    // Seed LanguageSpoken
    dbContext.LanguageSpokens.AddRange(
        new LanguageSpoken { Id = Guid.NewGuid(), Name = "English" },
        new LanguageSpoken { Id = Guid.NewGuid(), Name = "Spanish" },
        new LanguageSpoken { Id = Guid.NewGuid(), Name = "Portuguese" }
    );

    // Seed Schools
    dbContext.Schools.AddRange(
        new School { Id = Guid.NewGuid(), Name = "Ned", Country = "Ireland", City = "Limerick" },
        new School { Id = Guid.NewGuid(), Name = "Student Campus", Country = "Ireland", City = "Limerick" },
        new School { Id = Guid.NewGuid(), Name = "ELI", Country = "Ireland", City = "Limerick" }
    );

    dbContext.SaveChanges();
}
