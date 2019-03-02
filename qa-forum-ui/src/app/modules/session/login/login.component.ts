import { Component, OnInit } from '@angular/core';

//Utils
import { AuthService } from '../../../core/services/auth.services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login();
  }
}
