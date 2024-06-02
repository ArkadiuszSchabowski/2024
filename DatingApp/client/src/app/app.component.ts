import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'Dating App';
  baseUrl = 'http://localhost:5000/api/'
  users: any;

  constructor(public httpClient: HttpClient){
  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(){
    this.httpClient.get('https://localhost:5000/api/users').subscribe({
      next: response => {
        console.log(response);
        this.users = response;
      },
      error: error => console.log(error)
    })
  }
}