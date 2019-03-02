import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ApiService } from '../../../core/services/api.service'
import { Question } from '../../../core/models/question'
import { Answer } from '../../../core/models/answer'

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {

  questionId: number;
  question: Question;
  answers: Answer[];

  constructor(private activatedRoute: ActivatedRoute,
    private apiService: ApiService,
    private router: Router) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.questionId = params['id'];
    });

    this.getQuestion();
    this.getAnswers();
  }

  getQuestion() {
    this.apiService.getQuestion(this.questionId)
      .subscribe((data: any) => {
        if(data) {
          this.question = data;
        }
      });
  }

  getAnswers() {
    this.apiService.getAnswers(this.questionId)
      .subscribe((data: any) => {
        if(data) {
          this.answers = data;
        }
      });
  }

  answer() {
    this.router.navigate(['/answer/' + this.questionId]);
  }

}
