import { Component, EventEmitter, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  @Output() cancelRegister = new EventEmitter();
  model: any ={};

  constructor(public accountService: AccountService, private toastr: ToastrService){

  }

  registerUser(){
    console.log(this.model);
    this.accountService.registerUser(this.model).subscribe({
      next: response => console.log(response),
      error: error => {
        this.toastr.error(error.error);
      }
    })
  }

  cancel(){
    this.cancelRegister.emit(false);
  }
}