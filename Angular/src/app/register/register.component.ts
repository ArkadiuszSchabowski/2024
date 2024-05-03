import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(public accountService: AccountService){

  }
  model: any = {};
  hidePassword: boolean = true;
  hideRepeatPassword: boolean = true;

  register(){
    console.log(this.model);
  }
}
