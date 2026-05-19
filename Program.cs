using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using MyBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register the Database Context
builder.Services.AddDbContext<ProductContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("devCon")));
builder.Services.AddDbContext<StockContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("devCon")));

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Backend API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        // This path MUST match the version name "v1" used above
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Backend API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
