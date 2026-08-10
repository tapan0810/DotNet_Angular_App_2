using DotNet_Angular_App_2.Data;
using DotNet_Angular_App_2.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();


// Database

builder.Services.AddDbContext<ClassDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


// CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// Repository

builder.Services.AddScoped<IClassRepository, ClassRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}


app.UseHttpsRedirection();


// IMPORTANT: CORS must be enabled

app.UseCors("AngularPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();