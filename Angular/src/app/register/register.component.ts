import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {}
  model: any = {};
  hidePassword: boolean = true;
  hideRepeatPassword: boolean = true;

  login() {
    this.router.navigateByUrl('/login');
  }
  register() {
    this.accountService.register(this.model).subscribe({
      next: () => this.toastr.success('Zarejestrowano pomyślnie!'),
      error: (error) => {
        if (error.error.title) {
          this.toastr.error('Niepoprawne dane rejestracji!');
        } else if (error.status === 409) {
          this.toastr.error('Wybrana nazwa użytkownika jest już zajęta!');
        } else if (error.status === 400) {
          this.toastr.error('Wprowadzone hasła są różne!');
        } else {
          this.toastr.error('Błąd serwera!');
        }
      },
    });
  }
}
