import { Component } from '@angular/core';
import { AccountService } from './_service/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'Angular';
  isNavbar = false;

  constructor(public accountService: AccountService, public router: Router){
    
  }
  isHomePage(): boolean {
    return this.router.url === '/';
  }
  hideSideNav(){
    this.isNavbar = false;
  }
}
