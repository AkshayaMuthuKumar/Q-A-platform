import { Component, OnInit } from '@angular/core';
import { Router  } from '@angular/router';

import { ApiService } from '../../../core/services/api.service'
import { Question } from '../../../core/models/question'

@Component({
  selector: 'app-ask',
  templateUrl: './ask.component.html',
  styleUrls: ['./ask.component.scss']
})
export class AskComponent implements OnInit {

  question: string;
  description: string;
  questionInput: Question;
  constructor(private apiService: ApiService, 
    private router: Router) { }

  ngOnInit() {
  }

  createQuestion() {

    this.questionInput = new Question();
    this.questionInput.Value = this.question;
    this.questionInput.Description = this.description;
    this.apiService.addQuestion(this.questionInput).subscribe(
      (data: any) => {
        if (data) {
          this.router.navigate(['']);
        }
      }
    );
  }
}
