import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient) {}

  baseUrl: string = "https://localhost:7113/api/"
  flashcards: any;

  ngOnInit() {

      this.http.get(this.baseUrl + "flashcard").subscribe({
      next: response => {
      this.flashcards = response,
      console.log(this.flashcards)},
      error: error =>  console.error(error),
      complete: () => console.log("request has completed")
    });
  }
}