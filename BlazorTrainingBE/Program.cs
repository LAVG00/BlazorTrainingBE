using BlazorTrainingBE.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


const string GetGameEndPintName = "GetGame";

List<GameDto> games = [
    new(1, "Dark Souls", "RPG", 549.00M, new DateOnly(2011, 9, 22)),
    new(2, "Pokemon Platinum", "RPG", 800.00M, new DateOnly(2008, 9, 13)),
    new(3, "Monster Hunter Rise", "ARPG", 490.00M, new DateOnly(2021, 3, 26)),
    ];

// GET /games
app.MapGet("games", () => games);

//GET /game/{id}
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndPintName);

//POST /games
app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndPintName, new { id = game.Id }, game);
});

//PUT /games/{id}
app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);
    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});

//DELETE /games/{id}
app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
});


app.Run();
