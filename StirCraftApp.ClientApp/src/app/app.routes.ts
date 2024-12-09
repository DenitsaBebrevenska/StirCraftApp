import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { RecipesComponent } from './features/recipes/recipes.component';
import { RecipeDetailsComponent } from './features/recipes/recipe-details/recipe-details.component';
import { LoginComponent } from './features/account/login/login.component';
import { RegisterComponent } from './features/account/register/register.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { ServerErrorComponent } from './shared/components/server-error/server-error.component';
import { authGuard } from './core/guards/auth.guard';
import { CooksComponent } from './features/cooks/cooks.component';
import { CookDetailsComponent } from './features/cooks/cook-details/cook-details.component';
import { RecipeCookComponent } from './features/recipes/recipe-cook/recipe-cook.component';
import { LeaderboardComponent } from './features/cooks/leaderboard/leaderboard.component';
import { IngredientsComponent } from './features/ingredients/ingredients.component';
import { SuggestIngredientComponent } from './features/ingredients/suggest-ingredient/suggest-ingredient.component';
import { RecipeIngredientComponent } from './features/recipes/recipe-ingredient/recipe-ingredient.component';
import { BecomeCookComponent } from './features/cooks/become-cook/become-cook.component';
import { ProfilePageComponent } from './features/account/profile-page/profile-page.component';
import { CreateRecipeComponent } from './features/recipes/create-recipe/create-recipe.component';
import { UpdateRecipeComponent } from './features/recipes/update-recipe/update-recipe.component';
import { CookOwnRecipesComponent } from './features/recipes/cook-own-recipes/cook-own-recipes.component';
import { CookOwnRecipeComponent } from './features/recipes/cook-own-recipe/cook-own-recipe.component';
import { AvatarChangeComponent } from './features/account/avatar-change/avatar-change.component';
import { FavoritesComponent } from './features/recipes/favorites/favorites.component';
import { UpdateAboutComponent } from './features/cooks/update-about/update-about.component';



export const routes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: 'cook', loadChildren: () => import('./features/cooks/routes')
            .then(r => r.cookRoutes)
    },
    { path: 'cooks/top/10', component: LeaderboardComponent },
    { path: 'cooks', component: CooksComponent },
    { path: 'cooks/:id', component: CookDetailsComponent },
    { path: 'ingredients', component: IngredientsComponent },
    { path: 'ingredients/suggest', component: SuggestIngredientComponent, canActivate: [authGuard] },
    {
        path: 'admin', loadChildren: () => import('./features/admin/routes')
            .then(r => r.adminRoutes)
    },
    { path: 'recipes', component: RecipesComponent },
    { path: 'recipes/user-favorites', component: FavoritesComponent, canActivate: [authGuard] },
    { path: 'recipes/cook/:id', component: RecipeCookComponent },
    { path: 'recipes/ingredient/:id', component: RecipeIngredientComponent },
    { path: 'recipes/:id', component: RecipeDetailsComponent },
    {
        path: 'account', loadChildren: () => import('./features/account/routes')
            .then(r => r.accountRoutes)
    },
    { path: 'not-found', component: NotFoundComponent },
    { path: 'server-error', component: ServerErrorComponent },
    { path: '**', redirectTo: 'not-found', pathMatch: 'full' }
];
