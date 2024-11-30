import { Category } from "./category";
import { RecipeComment } from "./recipeComments";
import { RecipeImage } from "./recipeImage";
import { RecipeIngredient } from "./recipeIngredient";

export type RecipeDetailed = {
    id: number;
    name: string;
    preparationSteps: string;
    difficultyLevel: string;
    cookName: string;
    createdOn: string;
    updatedOn: string;
    ingredients: RecipeIngredient[];
    images: RecipeImage[];
    rating: number;
    likes: number;
    categories: Category[];
    comments: RecipeComment[]
}