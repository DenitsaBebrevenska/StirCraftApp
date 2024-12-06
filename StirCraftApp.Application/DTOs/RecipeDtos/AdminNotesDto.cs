using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class AdminNotesDto
{
    [StringLength(RecipeNameMaxLength, ErrorMessage = StringMaxLengthValidationErrorMessage)]
    public string? AdminNotes { get; set; }
}
