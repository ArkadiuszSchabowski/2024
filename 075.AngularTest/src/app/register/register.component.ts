import { Component, EventEmitter, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  @Output() cancelRegister = new EventEmitter();
  model: any ={};

  constructor(public accountService: AccountService){

  }

  registerUser(){
    console.log(this.model);
    this.accountService.registerUser(this.model).subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  cancel(){
    this.cancelRegister.emit(false);
  }
}