import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_service/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{

  model: any = {};
  isLogin = false;

  constructor(public accountService: AccountService){

  }
  ngOnInit(): void {
    this.getCurrentUser();
  }

getCurrentUser(){
  this.accountService.currentUser$.subscribe({
    next: user => this.isLogin = !!user,
    error: error => console.log(error)
  })
}

  login(){
    this.isLogin = true;
  // this.accountService.login(this.model).subscribe({
  //   next: response => {
  //   this.model = response;
  // },    
  //   error: error => console.log(error)
  // })
}

  logout(){
    this.accountService.logout();
    this.isLogin = false;
  }
}
