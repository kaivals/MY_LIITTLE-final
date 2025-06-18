using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using mylittle_project.Application.Interfaces;
using mylittle_project.infrastructure.Data;
using mylittle_project.infrastructure.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("mylittle-project.infrastructure") 
    )
);



builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();               
    app.MapScalarApiReference();    
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
