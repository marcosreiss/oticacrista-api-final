using Microsoft.EntityFrameworkCore;
using OticaCrista.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<OticaCristaContext>(o =>
{
    o.UseMySQL(builder.Configuration.GetConnectionString("ConnectionString")!);
});

builder.Services.AddDateOnlyTimeOnlyStringConverters();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
