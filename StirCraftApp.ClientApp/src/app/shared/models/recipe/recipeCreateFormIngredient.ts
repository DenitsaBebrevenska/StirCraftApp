import { MeasurementUnit } from "../measurementUnit/measurementUnit";

export type RecipeCreateFormIngredient = {
    ingredientId: number;
    quantity?: number;
    measurementUnitId?: number 
}