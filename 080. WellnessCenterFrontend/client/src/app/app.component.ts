import { Component, OnInit } from '@angular/core';
import { massageDto } from './_models/massageDto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'client';
  massages: massageDto[] =[];

  ngOnInit(): void {
    this.getUsers();
  }

  async getUsers(){
    let baseUrl: string="http://localhost:8090/api/massage";
    let data = await fetch(baseUrl);
    let json = await data.json();
    this.massages = json;
  }
}