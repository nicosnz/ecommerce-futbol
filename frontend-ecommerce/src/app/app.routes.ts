import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegistrarseComponent } from './registrarse/registrarse.component';

export const routes: Routes = [
    {path:'home', component:HomeComponent},
    {path: 'login', component:LoginComponent},
    {path: 'registrarse', component:RegistrarseComponent},
    {path:'**', redirectTo:'/home', pathMatch: 'full'},
    {path:'', redirectTo:'/home', pathMatch: 'full'}
];
