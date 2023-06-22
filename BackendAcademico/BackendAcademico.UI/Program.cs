using BackendAcademico.Application.Services;
using BackendAcademico.Domain.Interfaces;
using BackendAcademico.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IEstudianteService, EstudianteService>();
builder.Services.AddTransient<IInscripcionService, InscripcionService>();
builder.Services.AddTransient<IMateriaService, MateriasService>();
builder.Services.AddTransient<IAcademicoRepository, BackendAcademicoRepository>();

builder.Services.AddAutoMapper(typeof(AutomapperProfile));
builder.Services.AddDbContext<BackendAcademicoDBContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("AcademicoDB"),
        new MariaDbServerVersion(new Version(10, 5)), optionsAction =>
        {
            optionsAction.SchemaBehavior(MySqlSchemaBehavior.Ignore);
            optionsAction.MigrationsAssembly(typeof(Program).Assembly.FullName);
        });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
