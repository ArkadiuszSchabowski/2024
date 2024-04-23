import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  baseUrl = "https://localhost:7004/api/"
  massages: any;

  constructor(public httpClient: HttpClient, public accountService: AccountService){

  }
  ngOnInit(): void {
    this.setCurrentUser();
  }
  setCurrentUser(){
    const token: (string | null) = localStorage.getItem('token');
    if(token){
      this.accountService.setCurrentUser(token);
    }
  }
}