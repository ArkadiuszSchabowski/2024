import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Wellness Center';
  baseUrl = 'http://localhost:8090/api/massage';
  massages: any;
  email: string = "";
  isLogin : boolean = false;

  constructor(private http: HttpClient){

  }
  ngOnInit(): void {
    this.GetMassages();
  }

  GetMassages(){
    this.http.get(this.baseUrl).subscribe({
      next: response => this.massages = response,
      error: error => console.log("error" + error)
    })
  }
  updateErrorMessage(){

  }
}
