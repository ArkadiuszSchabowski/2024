import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl: string = 'https://localhost:7004/api/';

  currentUserSource = new BehaviorSubject<string | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private httpClient: HttpClient) {
    this.setCurrentUser()
  }

setCurrentUser(){
  const token = localStorage.getItem('token')
  this.currentUserSource.next(token);
}

  login(model: any) {
    console.log(model);
    return this.httpClient
      .post<string>(this.baseUrl + 'account/login', model)
      .pipe(
        map((response) => {
          const token: string = response;
          if (token) {
            localStorage.setItem('token', token);
            this.currentUserSource.next(token);
          }
        })
      );
  }
  logout(){
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
  }
}