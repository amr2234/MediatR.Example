

using Identity.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.ServicesRegsiter(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "AuthAPI");
    });
}
app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();
app.Run();





