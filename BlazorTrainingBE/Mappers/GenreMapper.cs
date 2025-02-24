using BlazorTrainingBE.Dtos;
using BlazorTrainingBE.Entities;

namespace BlazorTrainingBE.Mappers
{
    public static class GenreMapper
    {
        public static GenreDto ToGenreDto(this Genre genre)
        {
            return new GenreDto(genre.Id, genre.Name);
        }
    }
}
