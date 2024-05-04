import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  hide = true;
  model: any = {};

  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService ){
    
  }


  login(){
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response),
        this.router.navigateByUrl("/");
      },
      error: error => {
        console.log(error);
        this.toastr.error(error.error);
      }
    })
  }
  register(){
    this.router.navigateByUrl("/register");
  }
}
