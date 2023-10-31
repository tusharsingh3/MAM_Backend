using MAM.backend.Database;
using MAM.backend.Service;
using MAM.backend.Service.ServiceManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
Tuple<DBManager, bool> dbmanager = new DBFactory().CreateDatabase("mysql", "Server=127.0.0.1;Port=3306;Database=test;User=root;Password=admin;");

if (dbmanager.Item2 == true)
{
	builder.Services.AddScoped<UserManager>(provider => new ServiceFactory(dbmanager.Item1).CreateUserService("mysql"));
}

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

