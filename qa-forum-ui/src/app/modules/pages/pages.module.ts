import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }   from '@angular/forms';

import { AskComponent } from './ask/ask.component';
import { AnswerComponent } from './answer/answer.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { QuestionComponent } from './question/question.component';

@NgModule({
  declarations: [AskComponent, AnswerComponent, DashboardComponent, QuestionComponent],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class PagesModule { }
