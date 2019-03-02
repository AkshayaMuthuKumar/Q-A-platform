import { Component, OnInit } from '@angular/core';
import { Router, NavigationStart  } from '@angular/router';

import {AuthService} from '../../../core/services/auth.services'

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.scss']
})
export class TopNavComponent implements OnInit {

  showTopNav: boolean;
  userName:string;

  constructor(private router: Router,
    private authService: AuthService) { 
      router.events.forEach((event) => {
        if (event instanceof NavigationStart) {
          if (event['url'] == '/login') {
            this.showTopNav = false;
          } else {
            this.showTopNav = true;
          }
        }
      });
    }

  ngOnInit() {
    setTimeout(() => {
      this.userName = this.authService.name;
    }, 1000);
  }

  logout() {
    this.authService.logoff();
    this.router.navigate(['/login']);
  }
}
