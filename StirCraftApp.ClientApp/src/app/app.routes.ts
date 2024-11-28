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
import { IngredientDetailedComponent } from './features/admin/ingredient-detailed/ingredient-detailed.component';
import { CreateIngredientComponent } from './features/admin/create-ingredient/create-ingredient.component';
import { SuggestIngredientComponent } from './features/ingredients/suggest-ingredient/suggest-ingredient.component';
import { AdminPanelIngredientsComponent } from './features/admin/admin-panel-ingredients/admin-panel-ingredients.component';
import { EditIngredientComponent } from './features/admin/edit-ingredient/edit-ingredient.component';
import { RecipeIngredientComponent } from './features/recipes/recipe-ingredient/recipe-ingredient.component';
import { BecomeCookComponent } from './features/cooks/become-cook/become-cook.component';
import { ProfilePageComponent } from './features/user/profile-page/profile-page.component';
import { CreateRecipeComponent } from './features/recipes/create-recipe/create-recipe.component';



export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'cook/become', component: BecomeCookComponent},
    {path: 'cooks/top/10', component: LeaderboardComponent},
    {path: 'cooks', component: CooksComponent},
    {path: 'cooks/:id', component: CookDetailsComponent},
    {path: 'ingredients', component: IngredientsComponent},
    {path: 'ingredients/suggest', component: SuggestIngredientComponent},
    {path: 'admin/ingredients', component: AdminPanelIngredientsComponent},
    {path: 'admin/ingredients/create', component: CreateIngredientComponent},
    {path: 'admin/ingredients/edit/:id', component: EditIngredientComponent},//, canActivate: [authGuard]
    {path: 'admin/ingredients/:id', component: IngredientDetailedComponent},
    {path: 'recipes', component: RecipesComponent},
    {path: 'recipes/create', component: CreateRecipeComponent, canActivate: [authGuard]},
    {path: 'recipes/:id', component: RecipeDetailsComponent},
    {path: 'recipes/cook/:id', component: RecipeCookComponent},
    {path: 'recipes/ingredient/:id', component: RecipeIngredientComponent},
    {path: 'account/login', component: LoginComponent},
    {path: 'account/register', component: RegisterComponent},
    {path: 'account/profile', component: ProfilePageComponent},
    {path: 'not-fount', component: NotFoundComponent},
    {path: 'server-error', component: ServerErrorComponent},
    {path: '**', redirectTo: 'not-found', pathMatch: 'full'}    
];
