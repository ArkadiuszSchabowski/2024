import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = "https://localhost:7004/api/"

  private currentUserSource = new BehaviorSubject<string | null>(null);
  currentUser$: any = this.currentUserSource.asObservable();
  token: string ="";

  constructor(private httpClient: HttpClient) {
   }


  login(model: any){
    return this.httpClient.post(this.baseUrl + "account/login", model).pipe(
      map((response: any) => {
        console.log(response);
        const token: string = response
        if(token){
          localStorage.setItem('token', response)
          this.currentUserSource.next(token);
        }
      } 
      )
    )
  }
  setCurrentUser(token: string){
    this.currentUserSource.next(token);
  }

  logout(){
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
  }
}
