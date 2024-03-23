import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn: boolean = false;

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {}

  login() {
    // Przygotowanie danych logowania
    const loginData = {
      name: this.model.name, // Zachowujemy nazwę pola jako 'name'
      password: this.model.password // Przesyłamy hasło jako tekst jawny
    };
    console.log(loginData);

    // Wysłanie żądania logowania z hasłem jako tekstem jawny
    this.accountService.login(loginData).subscribe({
      next: (response: any) => { // Zadeklarowano typ 'response' jako 'any'
        console.log('Odpowiedź z serwera:', response);
      
        const token = response;
        
        // Tutaj możesz wykonać operacje na tokenie, np. przechowywać go w lokalnej pamięci
        localStorage.setItem('token', token);
        
        // Ustawiamy flagę loggedIn na true
        this.loggedIn = true;
      },
      error: error => console.log('Błąd logowania:', error)
    });
  }
}