using Microsoft.EntityFrameworkCore;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Repositories.Repository;
using Net_React.Server.Service;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers(); 

//Connect to  DB
var connectionString = builder.Configuration.GetConnectionString("PostgreDB");
builder.Services.AddScoped((provider) => new NpgsqlConnection(connectionString));

//Connect to DbContext
builder.Services.AddDbContext<ECommerceSampContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Sign in Repositories
builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//Sign in Services
builder.Services.AddScoped<CategoryService>();


//// Seed Data
//builder.Services.AddDbContext<ECommerceSampContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();
//app.MapAreaControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapFallbackToFile("/index.html");

app.Run();
