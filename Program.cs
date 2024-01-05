using DotNetMinimalAPI.Data;
using Microsoft.EntityFrameworkCore;
using DotNetMinimalAPI.Models;  // Add this using directive
using DotNetMinimalAPI.DTOs;  // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add AutoMapper configuration
builder.Services.AddAutoMapper(typeof(Program));  // Assuming AutoMapperProfile is in the same assembly as Program

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CinemaApiDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    options.EnableSensitiveDataLogging(); // Log sensitive data during development
});

// Configure AutoMapper
// builder.Services.AddAutoMapper(cfg =>
// {
//     cfg.CreateMap<Room, RoomDTO>();
//     cfg.CreateMap<RoomDTO, Room>();
// }, typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Ensure the database is created and apply migrations
// using (var scope = app.Services.CreateScope())
// {
//     var dbContext = scope.ServiceProvider.GetRequiredService<CinemaApiDbContext>();

//     // Check if the database exists, if not, create it
//     if (!dbContext.Database.CanConnect())
//     {
//         dbContext.Database.EnsureCreated();
//         dbContext.Database.Migrate();
//     }
// }

app.Run();
