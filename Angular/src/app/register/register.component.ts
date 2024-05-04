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
      next: (response) => console.log(response),
      error: (error) => this.toastr.error(error.error),
    });
  }
}
