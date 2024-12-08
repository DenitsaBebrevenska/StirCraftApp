using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;


namespace StirCraftApp.Application.DTOs.ImageDtos;
public class RecipeImageDto : BaseDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(ImageUrlMaxLength)]
    public required string Url { get; set; }
}
