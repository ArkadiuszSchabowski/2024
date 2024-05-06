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
      next: () => {
        this.router.navigateByUrl("/");
      },
      error: error => {
        if(error.error.title){
          this.toastr.error("Pola e-mail i hasło są wymagane!");
        }
        else if(error.status === 0){
          this.toastr.error("Błąd serwera, spróbuj ponownie później lub skontaktuj się z administratorem.");
        }
        else{
          this.toastr.error(error.error + "!");
        }
        console.log(error);
      }
    })
  }
  register(){
    this.router.navigateByUrl("/register");
  }
}
