import { MeasurementUnit } from "../measurementUnit/measurementUnit";

export type RecipeCreateFormIngredient = {
    id: number;
    quantity?: number;
    measurementUnitId?: number 
}