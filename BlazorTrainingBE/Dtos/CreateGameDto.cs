﻿using System.ComponentModel.DataAnnotations;

namespace BlazorTrainingBE.Dtos
{
    public record class CreateGameDto(
        [Required][StringLength(50)] string Name,
        int GenreId,
        [Range(1, 2000)] decimal Price,
        DateOnly ReleaseDate
    );

}
