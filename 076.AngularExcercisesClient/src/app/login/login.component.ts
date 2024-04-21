import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';
import { HttpClient } from '@angular/common/http';
import { AppComponent } from '../app.component';
import { LoginDto } from '../_models/LoginDto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  hide = true;
  model: any = {};
  isLogin: boolean = false;

  constructor(
    public accountService: AccountService,
    private httpClient: HttpClient,
    private appComponent: AppComponent
  ) {}
  resetPassword() {
    console.log('Reset Password');
  }
  login() {
    this.accountService.login(this.model);
    this.isLogin = true;
  }
}
