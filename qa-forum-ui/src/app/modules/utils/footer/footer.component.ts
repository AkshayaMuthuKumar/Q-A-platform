import { Component, OnInit } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  showFooter: boolean;

  constructor(private router: Router) {
    router.events.forEach((event) => {
      if (event instanceof NavigationStart) {
        if (event['url'] == '/login') {
          this.showFooter = false;
        } else {
          this.showFooter = true;
        }
      }
    });
  }

  ngOnInit() {

  }
}
