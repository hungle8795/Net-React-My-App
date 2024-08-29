using System.Text;
using backend.Data;
using backend_dotnet7.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Net_React.Server.Interfaces;
using Net_React.Server.Models;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
      builder =>
      {
          builder.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod();
      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Please enter your token with this format: ''Bearer YOUR_TOKEN''",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "bearer",
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

// Add AuthenticationSchema and JwtBearer
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILogService, LogService>();

//builder.Services.AddScoped<ICartService, CartService>();
//builder.Services.AddScoped<ICartItemService, CartItemService>();

builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

// Config Identity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

var app = builder.Build();

app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

else if (app.Environment.IsProduction())
{
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-commerce API v1");
    });
}

app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();