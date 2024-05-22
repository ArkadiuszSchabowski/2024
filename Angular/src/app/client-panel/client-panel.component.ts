import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { CurrentUserDto } from '../_models/currentUserDto';
import { UpdateUserDto } from '../_models/updateUserDto';

@Component({
  selector: 'app-client-panel',
  templateUrl: './client-panel.component.html',
  styleUrls: ['./client-panel.component.css']
})
export class ClientPanelComponent {

  id: number = 0;
  baseUrl = environment.apiUrl;
  currentUser = new BehaviorSubject<CurrentUserDto | null>(null);
  currentUser$ = this.currentUser.asObservable();
  model: UpdateUserDto = {} as UpdateUserDto;

  isEditionMode = false;

  constructor(private httpClient: HttpClient){
    this.getUserID();
  }

  getUserID() {
    const token = localStorage.getItem('token');
    if (!token) {
      console.log("No token found in localStorage");
      return;
    }
    
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    this.httpClient.get<number>(this.baseUrl + "user/currentUser", { headers })
      .subscribe({
        next: response => {
          this.id = response;
          this.getUserData(this.id);
        },
        error: error => console.log(error)
      });
  }

  getUserData(id: number){
    this.httpClient.get<CurrentUserDto>(this.baseUrl + `user/${id}`).subscribe({
      next: response => this.currentUser.next(response),
      error: error => console.log(error)
    });
  }
  goToEditionMode(){
    this.isEditionMode = true;
  }
  changeUserData(){
    console.log(this.model);
    this.httpClient.put<UpdateUserDto>(this.baseUrl + `user/${this.id}`, this.model).subscribe({
      next: response => {
        console.log(response);
        this.getUserData(this.id);
      },
      error: error => console.log(error)
    })
    this.isEditionMode = false;
  }
}
