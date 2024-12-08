namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class FavoriteRecipeToggleDto : BaseDto
{
    public bool IsFavorite { get; set; }

    public uint TotalLikes { get; set; }
}
