using Microsoft.EntityFrameworkCore;
using KitboxAPI.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization; // ✅ Pour convertir les enums en string dans les réponses JSON

var builder = WebApplication.CreateBuilder(args);

// 🔹 Connexion DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(10, 5)),
        mysqlOptions => mysqlOptions.EnableRetryOnFailure()
    )
);

// 🔹 Sérialisation enum → string (ex: "disponible" au lieu de 0)
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Test de la connexion
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        dbContext.Database.OpenConnection();
        Console.WriteLine("✅ Connexion à MariaDB réussie !");
        dbContext.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Erreur de connexion à MariaDB : {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
