using BlazorTrainingBE.Dtos;

namespace BlazorTrainingBE.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndpointName = "GetGame";

        private static readonly List<GameDto> games = [
            new(1, "Dark Souls", "RPG", 549.00M, new DateOnly(2011, 9, 22)),
            new(2, "Pokemon Platinum", "RPG", 800.00M, new DateOnly(2008, 9, 13)),
            new(3, "Monster Hunter Rise", "ARPG", 490.00M, new DateOnly(2021, 3, 26)),
        ];

        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games");

            // GET /games
            group.MapGet("/", () => games);

            //GET /game/{id}
            group.MapGet("/{id}", (int id) =>
            {
                GameDto? game = games.Find(game => game.Id == id);
                return game is null ? Results.NotFound() : Results.Ok(game);
            }
            ).WithName(GetGameEndpointName);

            //POST /games
            group.MapPost("/", (CreateGameDto newGame) =>
            {
                GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);
                games.Add(game);
                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            });

            //PUT /games/{id}
            group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
            {
                var index = games.FindIndex(game => game.Id == id);

                if (index == -1)
                {
                    return Results.NotFound();
                }

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
            group.MapDelete("/{id}", (int id) =>
            {
                games.RemoveAll(game => game.Id == id);
                return Results.NoContent();
            });

            return group;
        }
    }
}
