import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) {}

  baseUrl: string = 'https://localhost:7113/api/';
  flashcards: any;

  ngOnInit() {
    this.getUsers();
    this.setCurrentUser();
  }

  getUsers() {
    this.http.get(this.baseUrl + 'flashcard').subscribe({
      next: (response) => {
        (this.flashcards = response), console.log(this.flashcards);
      },
      error: (error) => console.error(error),
      complete: () => console.log('request has completed'),
    });
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) {
      return;
    }
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
