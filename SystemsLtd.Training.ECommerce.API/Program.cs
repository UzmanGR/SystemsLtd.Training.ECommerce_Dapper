using Microsoft.EntityFrameworkCore;
using SystemsLtd.Training.ECommerce.Repository;
using SystemsLtd.Training.ECommerce.Repository.Interface;
using SystemsLtd.Training.ECommerce.Service;
using SystemsLtd.Training.ECommerce.Service.Interface;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context,config) => 
{
    config.WriteTo.Console();
});

// Add services to the container.
builder.Services.AddDbContext<ECommerceDBContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<ECommerceDBContext>(options =>
//               options.UseSqlite(("filename=Data/Database/Issue.db")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


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
