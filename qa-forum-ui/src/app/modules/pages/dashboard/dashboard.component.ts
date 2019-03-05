import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ApiService } from '../../../core/services/api.service'

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  questions: any;

  constructor(private apiService: ApiService,
    private router: Router) { }

  ngOnInit() {
    this.getQuestions();
  }

  getQuestions() {
    this.apiService.getQuestions()
      .subscribe((data: any) => {
        if (data) {
          this.questions = data;
        }
      });
  }

  navigateToQuestion(id) {
    this.router.navigate(['/question/' + id]);
  }

  answer(id) {
    this.router.navigate(['/answer/' + id]);
  }

  ask() {
    this.router.navigate(['/ask']);
  }
}
