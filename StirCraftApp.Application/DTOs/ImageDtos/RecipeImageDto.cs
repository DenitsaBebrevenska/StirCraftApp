using StirCraftApp.Application.Contracts;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;


namespace StirCraftApp.Application.DTOs.Image;
public class RecipeImageDto : IDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(ImageUrlMaxLength)]
    public required string Url { get; set; }
}
