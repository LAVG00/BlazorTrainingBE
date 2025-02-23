﻿using System.ComponentModel.DataAnnotations;

namespace BlazorTrainingBE.Dtos
{
    public record class GameDto(
        int Id,
        [Required][StringLength(50)] string Name,
        [Required][StringLength(20)] string Genre,
        [Range(1, 2000)] decimal Price,
        DateOnly ReleaseDate
    );
}
