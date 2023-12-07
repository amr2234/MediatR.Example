
using Microsoft.EntityFrameworkCore;
using MediatR.Infrastructure;
using MediatR.Infrastructure.Data;
using MediatR.Example.DependencyInjection;
using MediatR.Domain.Interfaces.Features;
using MediatR.Domain.Interfaces.Persistence;
using MediatR.Example.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DBContext_App>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnectionString")));
builder.Services.AddScoped<IUnitofWORk, UnitOfWork>();
builder.Services.AddScoped(typeof(IProductAppSerives), typeof(ProductAppServices));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenaricRepository<>));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
