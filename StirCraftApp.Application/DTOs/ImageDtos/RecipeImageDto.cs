using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;


namespace StirCraftApp.Application.DTOs.ImageDtos;

/// <summary>
/// Data transfer object for RecipeImage entity
/// Gets validated as it deals with user input
/// </summary>
public class RecipeImageDto : BaseDto
{
    /// <summary>
    /// Unique identifier of the image
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Url leading to the image of the recipe
    /// </summary>
    [Required]
    [StringLength(ImageUrlMaxLength)]
    public required string Url { get; set; }
}
