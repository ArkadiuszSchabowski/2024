import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';
import { HttpClient } from '@angular/common/http';
import { AppComponent } from '../app.component';
import { LoginDto } from '../_models/LoginDto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  hide = true;
  model: any ={}
  constructor(public accountService: AccountService, private httpClient: HttpClient, private appComponent: AppComponent){

  }
  resetPassword(){
    console.log("Reset Password")
  }
  login(){
    console.log(this.model);
    this.httpClient.post(this.appComponent.baseUrl + "account/login", this.model).subscribe({
      next: 
      response => {
      this.model = response,
      this.accountService.isLogin = true
    },    
      error: error => console.log(error)
    })
  }
}
