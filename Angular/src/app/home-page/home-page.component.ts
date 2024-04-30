import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  constructor(public accountService: AccountService) {}

  isLoginPage = new BehaviorSubject<boolean>(true);
  isLoginPage$ = this.isLoginPage.asObservable();

  isRegisterPage = new BehaviorSubject<boolean>(false);
  isRegisterPage$ = this.isRegisterPage.asObservable();

  goToLoginPage() {
    this.isRegisterPage.next(false);
    this.isLoginPage.next(true);
    console.log("goToLogin - function");
  }
  goToRegisterPage() {
    this.isLoginPage.next(false);
    this.isRegisterPage.next(true);
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
