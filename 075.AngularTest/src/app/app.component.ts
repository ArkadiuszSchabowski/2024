import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  baseUrl = "https://localhost:7004/api/"
  massages: any;

  constructor(public httpClient: HttpClient){

  }
  ngOnInit(): void {
    this.getMassages();
  }
  getMassages(){
    this.httpClient.get(this.baseUrl + 'massage').subscribe({
      next: response => {
        console.log(response);
      this.massages = response},
      error: error => console.log(error)
    })
  }}