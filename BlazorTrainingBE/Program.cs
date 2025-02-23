using BlazorTrainingBE.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new(1, "Dark Souls", "RPG", 549.00M, new DateOnly(2011, 9, 22)),
    new(2, "Pokemon Platinum", "RPG", 800.00M, new DateOnly(2008, 9, 13)),
    new(3, "Monster Hunter Rise", "ARPG", 490.00M, new DateOnly(2021, 3, 26)),
    ];

// GET /games
app.MapGet("games", () => games);

//GET /game/{id}
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id));

//Post /game


app.Run();
