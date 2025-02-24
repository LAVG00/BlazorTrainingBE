using BlazorTrainingBE.Data;
using BlazorTrainingBE.Dtos;
using BlazorTrainingBE.Entities;
using BlazorTrainingBE.Mappers;

namespace BlazorTrainingBE.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndpointName = "GetGame";

        private static readonly List<GameSummaryDto> games = [
            new(1, "Dark Souls", "RPG", 549.00M, new DateOnly(2011, 9, 22)),
            new(2, "Pokemon Platinum", "RPG", 800.00M, new DateOnly(2008, 9, 13)),
            new(3, "Monster Hunter Rise", "ARPG", 490.00M, new DateOnly(2021, 3, 26)),
        ];

        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games").WithParameterValidation();

            // GET /games
            group.MapGet("/", () => games);

            //GET /game/{id}
            group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
            {
                Game? game = dbContext.Games.Find(id);
                return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
            }
            ).WithName(GetGameEndpointName);

            //POST /games
            group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
            {
                Game game = newGame.ToEntity();

                dbContext.Games.Add(game);
                dbContext.SaveChanges();

                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToGameDetailsDto());
            });

            //PUT /games/{id}
            group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
            {
                var index = games.FindIndex(game => game.Id == id);

                if (index == -1)
                {
                    return Results.NotFound();
                }

                games[index] = new GameSummaryDto(
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
