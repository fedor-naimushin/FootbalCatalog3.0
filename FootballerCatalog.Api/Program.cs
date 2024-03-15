using FootballerCatalog.Application.Services;
using FootballerCatalog.DataBase;
using FootballerCatalog.DataBase.Repositories;
using FootballerCatalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddDbContext<FootballerDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    builder.Services.AddScoped<IFootballersService, FootballersService>();
    builder.Services.AddScoped<IFootballersRepository, FootballersRepository>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
