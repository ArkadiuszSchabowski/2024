import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  constructor(public accountService: AccountService) {}

  isLoginPage: boolean = true;
  isRegisterPage: boolean = false;

  goToLoginPage() {
    this.isRegisterPage = false;
    this.isLoginPage = true;
    console.log("goToLogin - function");
  }

  goToRegisterPage() {
    this.isLoginPage = false;
    this.isRegisterPage = true;
    console.log("goToRegistration - function");
  }

  tabChanged(index: number) {
    if (index === 0) {
      this.goToLoginPage();
    } else if (index === 1) {
      this.goToRegisterPage();
    }
  }
}