﻿using Microsoft.AspNetCore.Identity;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.JoinedTables;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

//todo I probably don`t need soft deletable on this one as identity user deletion is handled by the identity framework
public class AppUser : IdentityUser, ISoftDeletable
{
    [MaxLength(UserDisplayNameMaxLength)]
    public string? DisplayName { get; set; }

    [MaxLength(ImageUrlMaxLength)]
    public string? AvatarUrl { get; set; }
    public virtual ICollection<UserFavoriteRecipe> FavoriteRecipes { get; set; } = new List<UserFavoriteRecipe>();

    public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();

    public virtual ICollection<RecipeRating> RecipesRatings { get; set; } = new List<RecipeRating>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}