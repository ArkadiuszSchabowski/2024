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
  menu: any;

  constructor(private accountService: AccountService){

  }

  login(){
    console.log(this.model);
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response)
        this.isLogin = true;
        console.log(this.isLogin);
      },
      error: error => console.log(error)
    });
  }
  logout(){
    this.isLogin = false;
  }
}
