using Microsoft.EntityFrameworkCore;
using MyApiProject.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();
