import { RecipeComment } from "./recipeComments";
import { RecipeImage } from "./recipeImage";
import { RecipeIngredient } from "./recipeIngredient";

export type RecipeDetailed = {
    id: number;
    name: string;
    preparationSteps: string;
    difficultyLevel: string;
    imageUrl?: string | null;
    cookName: string;
    createdOn: string;
    updatedOn: string;
    ingredients: RecipeIngredient[];
    images: RecipeImage[];
    rating: number;
    likes: number;
    comments: RecipeComment[]
}