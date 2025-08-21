using Microsoft.EntityFrameworkCore;
using sleepSystemAPI.Data;
using sleepSystemAPI.Models;
using sleepSystemAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Registro del contexto de base de datos
builder.Services.AddDbContext<SleepSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de servicios para inyección de dependencias
builder.Services.AddScoped<PsqiCalculator>();
builder.Services.AddScoped<IEvaluacionService, EvaluacionService>();

// Otros servicios
builder.Services.AddControllers();

// Configuración de CORS (si lo necesitas)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
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

app.UseCors("PermitirTodo");


app.UseAuthorization();

app.MapControllers();


app.Run();
