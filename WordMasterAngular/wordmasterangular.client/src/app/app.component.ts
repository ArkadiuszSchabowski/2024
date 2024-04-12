import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient) {}

  ngOnInit() {
    let baseUrl = "https://localhost:7113/api/"

    let url = this.http.get(baseUrl + "flashcard").subscribe();
    console.log(url);
  }
}
