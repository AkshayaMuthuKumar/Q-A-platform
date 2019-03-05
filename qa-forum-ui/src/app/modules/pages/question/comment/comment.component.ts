import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/filter';

import { ApiService } from '../../../../core/services/api.service'

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {

  questionId: string;
  answerId: string;
  comment: string;
  constructor(private activatedRoute: ActivatedRoute,
    private apiService: ApiService,
    private router: Router) { }

  ngOnInit() {
    this.questionId = this.activatedRoute.snapshot.queryParamMap.get('questionId');
    this.answerId = this.activatedRoute.snapshot.queryParamMap.get('answerId');
  }

  addComment() {
    if(this.questionId && !this.answerId) {
      this.apiService.addQuestionComment(this.questionId, this.comment).subscribe(
        (data: any) => {
          if (data) {
            this.router.navigate(['/question/' + this.questionId]);
          }
        }
      );
    } else if(this.answerId) {
      this.apiService.addAnswerComment(this.answerId, this.comment).subscribe(
        (data: any) => {
          if (data) {
            this.router.navigate(['/question/' + this.questionId]);
          }
        }
      );
    }
  }
}
