import { Category } from "./category";
import { RecipeIngredientDetailedDto } from "./recipeIngredientDetailedDto";
import { RecipeImage } from "./recipeImage";
import { RecipeIngredient } from "./recipeIngredient";

export type RecipeOwnDetailed = {
    id: number;
    name: string;
    preparationSteps: string;
    difficultyLevel: string;
    cookName: string;
    createdOn: string;
    updatedOn: string;
    ingredients: RecipeIngredientDetailedDto[];
    images: RecipeImage[];
    rating: number;
    likes: number;
    categories: Category[];
    isAdminApproved: boolean;
    adminNotes?: string;
}