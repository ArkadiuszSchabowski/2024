import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  title: string = 'Angular Excercises';
  baseUrl: string = 'https://localhost:7113/api/'
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  
  constructor(public httpClient: HttpClient)
  {

  }
  login(model: User){
    console.log(model );
    return this.httpClient.post<User>(this.baseUrl + "account/login", model).pipe(map((response: User) =>{
        const user = response;
        console.log("HEJ!");
        if(user){
          localStorage.setItem('user', JSON.stringify(user))
          console.log(localStorage.getItem('user'))
          this.currentUserSource.next(user);
        }
      })
    );
  }
setCurrentUser(user: User){
  this.currentUserSource.next(user);
}

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
