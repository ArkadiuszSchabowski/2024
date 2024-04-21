import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_service/account.service';
import { User } from './_models/User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  baseUrl: string = 'https://localhost:7113/api/'
  flashcards: any;
  isLogin: boolean = false;

  constructor(private http: HttpClient, public accountService: AccountService){

  }

  ngOnInit(): void {
    this.GetFlashCards()
    this.setCurrentUser();
  }

  GetFlashCards() {
    this.http.get(this.baseUrl + "flashcard").subscribe({
      next: response => this.flashcards = response,
      error: error => console.log(error)
    })
  }
  setCurrentUser(){
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
