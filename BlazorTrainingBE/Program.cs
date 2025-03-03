using BlazorTrainingBE.Data;
using BlazorTrainingBE.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);


var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEnpoints();

await app.MigrateDbAsync();

app.Run();
