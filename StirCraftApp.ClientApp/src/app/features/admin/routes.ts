import { Route } from "@angular/router";
import { authGuard } from "../../core/guards/auth.guard";
import { AdminPanelIngredientsComponent } from "./admin-panel-ingredients/admin-panel-ingredients.component";
import { CreateIngredientComponent } from "./create-ingredient/create-ingredient.component";
import { EditIngredientComponent } from "./edit-ingredient/edit-ingredient.component";
import { IngredientDetailedComponent } from "./ingredient-detailed/ingredient-detailed.component";
import { PendingRecipeComponent } from "./pending-recipe/pending-recipe.component";
import { PendingRecipesPreviewComponent } from "./pending-recipes-preview/pending-recipes-preview.component";
import { adminGuard } from "../../core/guards/admin.guard";

export const adminRoutes: Route[] = [
    { path: 'ingredients', component: AdminPanelIngredientsComponent, canActivate: [authGuard, adminGuard] },
    { path: 'recipes/pending-approval', component: PendingRecipesPreviewComponent, canActivate: [authGuard, adminGuard] },
    { path: 'recipes/pending-approval/:id', component: PendingRecipeComponent, canActivate: [authGuard, adminGuard] },
    { path: 'ingredients/create', component: CreateIngredientComponent, canActivate: [authGuard, adminGuard] },
    { path: 'ingredients/edit/:id', component: EditIngredientComponent, canActivate: [authGuard, adminGuard] },
    { path: 'ingredients/:id', component: IngredientDetailedComponent, canActivate: [authGuard, adminGuard] },
];