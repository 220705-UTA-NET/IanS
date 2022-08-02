global using P1API.Data;
global using Microsoft.EntityFrameworkCore;

string connectionString = "Server=tcp:sekidb.database.windows.net,1433;Initial Catalog=sekidb;" +
   "Persist Security Info=False;" +
   "User ID=sekiian;Password=Hello97!;MultipleActiveResultSets=False;Encrypt=True;" +
   "TrustServerCertificate=False;Connection Timeout=30;";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepositoryMonster>(sp => new SQLRepositoryMonster(connectionString, sp.GetRequiredService<ILogger<SQLRepositoryMonster>>()));
builder.Services.AddSingleton<IRepositoryCharacter>(sp => new SQLRepositoryCharacter(connectionString, sp.GetRequiredService<ILogger<SQLRepositoryCharacter>>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
