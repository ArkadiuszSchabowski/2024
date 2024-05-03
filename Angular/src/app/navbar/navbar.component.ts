import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {

  constructor(public accountService: AccountService, private router: Router) {
  }
  homePage(){
    this.router.navigateByUrl("/");
  }
  offer(){
    this.router.navigateByUrl("/massages")
  }
  login(){
    this.router.navigateByUrl("/login");
  }
  massages(){
    this.router.navigateByUrl("/");
  }
  booking(){
    this.router.navigateByUrl("/booking");
  }
  contact(){
    this.router.navigateByUrl("/contact");
  }

  logout(){
    this.accountService.logout();
  }
}
