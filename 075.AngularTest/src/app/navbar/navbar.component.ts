import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  title: string = "Angular Training";
  hide = true;
  model: any = {};
  isLogin = false;

  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService){
    this.setCurrentUser();
  }

setCurrentUser(){
  const user = localStorage.getItem('token');
  if(user){
    this.isLogin = true;
  }
}

  login(){
    this.accountService.login(this.model).subscribe({
      next: () => {

        this.router.navigateByUrl("/members");

        this.isLogin = true;
      },
      error: error => {
        this.toastr.error(error.error);
      }
    });
  }
  logout(){
    this.router.navigateByUrl("/");
    this.accountService.logout();
    this.isLogin = false;
  }

}
