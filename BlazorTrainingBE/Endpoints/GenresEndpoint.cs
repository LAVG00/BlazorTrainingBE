using BlazorTrainingBE.Data;
using BlazorTrainingBE.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BlazorTrainingBE.Endpoints
{
    public static class GenresEndpoint
    {
        public static RouteGroupBuilder MapGenresEnpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");

            group.MapGet("/", async (GameStoreContext dbContext) =>
                    await dbContext.Genres
                                   .Select(genre => genre.ToGenreDto())
                                   .AsNoTracking()
                                   .ToListAsync()
            );

            return group;
        }

    }
}
