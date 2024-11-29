
import { RecipeCreateFormImage } from "./recipeCreateFormImage";
import { RecipeCreateFormIngredient } from "./recipeCreateFormIngredient";

export class RecipeCreateForm{
    name: string = '';
    preparationSteps: string= '';
    difficultyLevel: string= '';
    recipeIngredients: RecipeCreateFormIngredient[] = [];
    recipeImages: RecipeCreateFormImage[] = [];
    categoryRecipes: number[] = [];
}