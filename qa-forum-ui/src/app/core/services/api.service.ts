import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment as env } from '../../../environments/environment';
import { Question } from '../../core/models/question';
import { Answer } from '../../core/models/answer';


const routes = {
  questions: 'questions',
  answers: 'answers',
  questionComments: 'questionComments',
  answerComments: 'answercomments'
};

@Injectable({
  providedIn: 'root'
})

export class ApiService {

  constructor(private httpClient: HttpClient) { }

  getQuestions() {
    return this.httpClient.get(env.apiServerBaseUrl + routes.questions);
  }

  getQuestion(id) {
    return this.httpClient.get(env.apiServerBaseUrl + routes.questions + "/" + id);
  }

  getAnswers(id) {
    return this.httpClient.get(env.apiServerBaseUrl + 'questions/' + id + '/answers');
  }

  addQuestion(question: Question) {
    return this.httpClient.post(env.apiServerBaseUrl + routes.questions, question);
  }

  addAnswer(answer: Answer) {
    return this.httpClient.post(env.apiServerBaseUrl + routes.answers, answer);
  }

  addAnswerComment(answerId, comment) {
    return this.httpClient.post(env.apiServerBaseUrl + routes.answerComments, {'Value': comment, 'AnswerId': answerId});
  }

  addQuestionComment(questionId, comment) {
    return this.httpClient.post(env.apiServerBaseUrl + routes.questionComments, {'Value': comment, 'QuestionId': questionId});
  }

  updateQuestion(id, question) {
    return this.httpClient.put(env.apiServerBaseUrl + routes.questions + '/' + id, question);
  }

  updateAnswer(id, answer) {
    return this.httpClient.put(env.apiServerBaseUrl + routes.answers + '/' + id, answer);
  }
}
