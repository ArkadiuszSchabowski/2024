import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';

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

  constructor(public accountService: AccountService){
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
      next: response => {
        console.log(response)
        this.isLogin = true;
      },
      error: error => console.log(error)
    });
  }
  logout(){
    this.accountService.logout();
    this.isLogin = false;
  }

}
