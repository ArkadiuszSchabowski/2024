import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {

  constructor(private accountService: AccountService) {
    this.getCurrentUser();
  }

  isLogin: boolean = false;

  getCurrentUser() {
    this.accountService.currentUser$.subscribe({
      next: token => this.isLogin = !!token,
      error: error => console.log(error)
    })
  }
  logout(){
    this.isLogin = false;
    this.accountService.logout();
  }
}
