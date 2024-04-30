import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  hide = true;
  model: any = {};

  constructor(private accountService: AccountService){
    
  }


  login(){
    this.accountService.login(this.model).subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }
  register(){

  }
}
