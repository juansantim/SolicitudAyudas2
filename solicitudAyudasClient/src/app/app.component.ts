import { Component } from '@angular/core';
import { NavigationEnd, NavigationStart, Router, RouterEvent } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'solicitudAyudasClient';
  showNav = false;

  constructor(private router: Router)
  {
    this.router.events.subscribe(routerEvent => {
      if(routerEvent instanceof NavigationEnd && this.router.url !== '/login'){
        this.showNav = true;
      }
    })
  }
}
