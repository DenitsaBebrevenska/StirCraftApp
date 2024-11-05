import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { RecipesComponent } from './features/recipes/recipes.component';
import { RecipeDetailsComponent } from './features/recipes/recipe-details/recipe-details.component';
import { LoginComponent } from './features/account/login/login.component';
import { RegisterComponent } from './features/account/register/register.component';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'recipes', component: RecipesComponent},
    {path: 'recipes/:id', component: RecipeDetailsComponent},
    {path: 'account/login', component: LoginComponent},
    {path: 'account/register', component: RegisterComponent},
    {path: '**', redirectTo: '', pathMatch: 'full'}    
];
