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
import { IngredientDetailedComponent } from './features/ingredients/ingredient-detailed/ingredient-detailed.component';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'cooks/top/10', component: LeaderboardComponent},
    {path:'cooks', component: CooksComponent},
    {path:'cooks/:id', component: CookDetailsComponent},
    {path: 'ingredients', component: IngredientsComponent},
    {path: 'ingredients/:id', component: IngredientDetailedComponent},
    {path: 'recipes', component: RecipesComponent},
    {path: 'recipes/:id', component: RecipeDetailsComponent},
    {path: 'recipes/cook/:id', component: RecipeCookComponent},
    {path: 'account/login', component: LoginComponent},
    {path: 'account/register', component: RegisterComponent},
    {path: 'recipes/create', component: NotFoundComponent, canActivate: [authGuard]}, //todo swap the component when it's ready
    {path: 'not-fount', component: NotFoundComponent},
    {path: 'server-error', component: ServerErrorComponent},
    {path: '**', redirectTo: 'not-found', pathMatch: 'full'}    
];
