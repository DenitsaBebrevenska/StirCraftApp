﻿namespace StirCraftApp.Domain.Constants;

/// <summary>
/// Constants for entity constraints
/// </summary>
public static class EntityConstraints
{
    //Category
    public const int CategoryMinLength = 3;
    public const int CategoryMaxLength = 100;

    //Comment
    public const int CommentTitleMinLength = 2;
    public const int CommentTitleMaxLength = 20;
    public const int CommentBodyMinLength = 2;
    public const int CommentBodyMaxLength = 500;

    //Reply
    public const int ReplyBodyMinLength = 2;
    public const int ReplyBodyMaxLength = 250;

    //Cook
    public const int CookAboutMinLength = 10;
    public const int CookAboutMaxLength = 500;

    //Ingredient
    public const int IngredientNameMinLength = 2;
    public const int IngredientNameMaxLength = 100;


    //Rank
    public const int RankTitleMinLength = 3;
    public const int RankTitleMaxLength = 30;

    //Recipe
    public const int RecipeNameMinLength = 2;
    public const int RecipeNameMaxLength = 100;
    public const int RecipeDescriptionMinLength = 50;
    public const int RecipeDescriptionMaxLength = 2_000;
    public const int RecipeAdminNotesMaxLength = 250;

    //Rating
    public const int RecipeRatingMinValue = 1;
    public const int RecipeRatingMaxValue = 5;

    //Image that will stay if is in user control
    public const int ImageUrlMaxLength = 2_048;

    //Unit
    public const int UnitNameMinLength = 2;
    public const int UnitNameMaxLength = 20;
    public const int UnitAbbreviationMaxLength = 5;

    //User
    public const int UserDisplayNameMinLength = 3;
    public const int UserDisplayNameMaxLength = 100;



}
