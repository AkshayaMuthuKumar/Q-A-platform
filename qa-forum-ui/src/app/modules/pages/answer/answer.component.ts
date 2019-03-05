import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ApiService } from '../../../core/services/api.service'
import { Answer } from '../../../core/models/answer'

@Component({
  selector: 'app-answer',
  templateUrl: './answer.component.html',
  styleUrls: ['./answer.component.scss']
})
export class AnswerComponent implements OnInit {

  questionId: number;
  answer: string;
  description: string;

  constructor(private activatedRoute: ActivatedRoute,
    private apiService: ApiService,
    private router: Router
  ) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.questionId = params['id'];
    });
  }

  createAnswer() {

    var answerInput = new Answer(); 
    answerInput.Value = this.answer;
    answerInput.Description = this.description;
    answerInput.QuestionId = this.questionId;

    this.apiService.addAnswer(answerInput).subscribe(
      (data: any) => {
        if (data) {
          this.router.navigate(['/question/' + this.questionId]);
        }
      }
    );
  }
}
