import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  tittle = "Witaj w aplikacji Word Master!"
  isLogin = false;
  model: any ={};

  constructor(private accountService: AccountService){

  }

getCurrentUser(){
  this.accountService.currentUser$.subscribe({
    next: user => this.isLogin = !!user,
    error: error => console.log(error)
    
  })
}

  login(){
    console.log(this.model)
    this.accountService.login(this.model).subscribe({
      next: response =>{
        console.log(response);
        this.isLogin = true;
      },
      error: error => console.log(error)
    })
  }
  logout(){
    this.accountService.logout();
    this.isLogin = false;
  }
}