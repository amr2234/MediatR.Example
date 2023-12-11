
using MediatR.Example.DependencyInjection;
using MediatR.Example.Middleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.ServicesRegsiter(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "Product WebAPI");
    });
}
app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
