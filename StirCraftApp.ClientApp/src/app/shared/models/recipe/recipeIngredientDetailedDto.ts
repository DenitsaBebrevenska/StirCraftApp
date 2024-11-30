export type RecipeIngredientDetailedDto = {
    id: number;
    name: string;
    quantity?: number;
    measurementUnitId?: number | null;
    measurementAbbreviation?: string | null;
    ingredientId: number;
    ingredientName: string;
}

//todo remove if not used in edit recipe