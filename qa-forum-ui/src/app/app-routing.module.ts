import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//Utils
import { AuthGuard } from './core/guards/auth.guard';

//Feature module components
import { LoginComponent } from './modules/session/login/login.component';
import { DashboardComponent } from './modules/pages/dashboard/dashboard.component';
import { AskComponent } from './modules/pages/ask/ask.component';
import { AnswerComponent } from './modules/pages/answer/answer.component';
import { QuestionComponent } from './modules/pages/question/question.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent},
  { path: '', component: DashboardComponent, canActivate: [AuthGuard]},
  { path: 'ask', component: AskComponent, canActivate: [AuthGuard]},
  { path: 'answer/:id', component: AnswerComponent, canActivate: [AuthGuard]},
  { path: 'question/:id', component: QuestionComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: false
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
