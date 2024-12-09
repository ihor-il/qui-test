using WeatherApp.Api.Utilities;
using WeatherApp.BLL;
using WeatherApp.DAL.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDAL(builder.Configuration)
    .AddBLL(builder.Configuration)
    .AddAPI();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
