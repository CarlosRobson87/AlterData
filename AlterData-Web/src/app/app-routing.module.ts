import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { AuthGuard } from './account/shared/auth.guard';
import { VotacaoComponent } from './votacao/votacao.component';
import { AuthenticationComponent } from './layout/authentication/authentication.component';
import { HomeComponent } from './layout/home/home.component';
import { RecursosComponent } from './recursos/recursos.component';

const routes: Routes = [
  { 
    path: '', 
    component: HomeComponent,
    children: [
      { path: '', component: VotacaoComponent },
      { path: 'recursos', component: RecursosComponent },
      { path: 'votacao', component: VotacaoComponent }
    ],
    canActivate: [AuthGuard]
  },
  { 
    path: '', 
    component: AuthenticationComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent}
    ]
  } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
