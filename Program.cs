using Microsoft.EntityFrameworkCore;
using PasswordChecker.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


var retryCount = 0;

while (retryCount < 10)
{
    try
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
        break;
    }
    catch (Exception ex)
    {
        retryCount++;
        if (retryCount >= 10)
        {
            throw;
        }
        await Task.Delay(3000);
    }
}


app.UseAuthorization();
app.MapControllers();

app.Run();


