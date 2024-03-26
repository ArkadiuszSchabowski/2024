import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'client';
  massages: any;
  baseUrl = 'http://localhost:8090/api/massage';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get(this.baseUrl).subscribe({
      next: (response) => (this.massages = response),
      error: (error) => console.log(error),
    });
  }
}
