import { Route } from "@angular/router";
import { authGuard } from "../../core/guards/auth.guard";
import { CookOwnRecipeComponent } from "../recipes/cook-own-recipe/cook-own-recipe.component";
import { CookOwnRecipesComponent } from "../recipes/cook-own-recipes/cook-own-recipes.component";
import { CreateRecipeComponent } from "../recipes/create-recipe/create-recipe.component";
import { UpdateRecipeComponent } from "../recipes/update-recipe/update-recipe.component";
import { BecomeCookComponent } from "./become-cook/become-cook.component";
import { UpdateAboutComponent } from "./update-about/update-about.component";

export const cookRoutes: Route[] = [
    { path: 'become', component: BecomeCookComponent, canActivate: [authGuard] },
    { path: 'about', component: UpdateAboutComponent, canActivate: [authGuard] },
    { path: 'recipes', component: CookOwnRecipesComponent, canActivate: [authGuard] },
    { path: 'recipes/create', component: CreateRecipeComponent, canActivate: [authGuard] },
    { path: 'recipes/:id/edit', component: UpdateRecipeComponent, canActivate: [authGuard] },
    { path: 'recipes/:id', component: CookOwnRecipeComponent, canActivate: [authGuard] },
];