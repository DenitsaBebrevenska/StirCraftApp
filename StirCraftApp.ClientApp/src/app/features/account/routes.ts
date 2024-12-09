import { Route } from "@angular/router";
import { authGuard } from "../../core/guards/auth.guard";
import { AvatarChangeComponent } from "./avatar-change/avatar-change.component";
import { LoginComponent } from "./login/login.component";
import { ProfilePageComponent } from "./profile-page/profile-page.component";
import { RegisterComponent } from "./register/register.component";

export const accountRoutes: Route[] = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'profile', component: ProfilePageComponent, canActivate: [authGuard] },
    { path: 'profile/avatar/change', component: AvatarChangeComponent, canActivate: [authGuard] },
];