import { Component } from '@angular/core';
import { AccountService } from './_service/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public accountService: AccountService, public router: Router){
    
  }
  title = 'Angular';
  isHomePage(): boolean {
    return this.router.url === '/';
  }
}
