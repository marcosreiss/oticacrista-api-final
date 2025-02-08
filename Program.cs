using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OticaCrista.Data;
using OticaCrista.Data.Repository;
using OticaCrista.Data.Repository.Product;
using OticaCrista.Models;
using OticaCrista.Repositories;
using OticaCrista.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<OticaCristaContext>(o =>
{
    o.UseMySQL(builder.Configuration.GetConnectionString("ConnectionString")!);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<OticaCristaContext>()
    .AddDefaultTokenProviders();

// Configurar autenticação JWT
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ServiceRepository>();
builder.Services.AddScoped<SaleRepository>();
builder.Services.AddScoped<PaymentRepository>();
builder.Services.AddScoped<EntryRepository>();

builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddAuthorization();

builder.Services.AddDateOnlyTimeOnlyStringConverters();



builder.Services.AddEndpointsApiExplorer();
// Configurar Swagger para suportar JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OticaCrista API", Version = "v1" });

    // Configurar autenticação Bearer Token no Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no formato: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OticaCrista API V1");
        c.RoutePrefix = "swagger"; // Swagger ficará acessível em /swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
