import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Dating App';
  users: any;

  constructor(private http: HttpClient, private accountService: AccountService){

  }
  ngOnInit(): void {
    this.getUsers();
    this.setCurrentUser();
    };
    getUsers(){
      let path = "https://localhost:5001/api/user";
      this.http.get(path).subscribe({
        next: response => this.users = response,
        error: error => console.error(error),
        complete: () => console.log("Request has completed")
        })
    }
    setCurrentUser(){
      const userString = localStorage.getItem('user');
      if(!userString) return; 
      const user: User = JSON.parse(userString);
      this.accountService.setCurrentUser(user);
    }
}
