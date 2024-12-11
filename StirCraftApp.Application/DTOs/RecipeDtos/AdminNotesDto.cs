using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.RecipeDtos;

/// <summary>
/// Data transfer object for admin notes to a recipe.
/// Gets validated as it deals with user input.
/// </summary>
public class AdminNotesDto : BaseDto
{
    /// <summary>
    /// Admin notes to a recipe if any
    /// </summary>
    [StringLength(RecipeNameMaxLength, ErrorMessage = StringMaxLengthValidationErrorMessage)]
    public string? AdminNotes { get; set; }
}
