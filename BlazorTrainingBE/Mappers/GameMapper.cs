using BlazorTrainingBE.Dtos;
using BlazorTrainingBE.Entities;

namespace BlazorTrainingBE.Mappers
{
    public static class GameMapper
    {
        public static Game ToEntity(this CreateGameDto game)
        {
            return new Game()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }

        public static GameDto ToDto(this Game game)
        {
            return new(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.ReleaseDate
            );
        }
    }
}
