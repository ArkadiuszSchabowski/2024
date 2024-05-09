import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-booking-without-login',
  templateUrl: './booking-without-login.component.html',
  styleUrls: ['./booking-without-login.component.css'],
})

export class BookingWithoutLoginComponent {
  constructor(
    public accountService: AccountService,
    private httpClient: HttpClient,
    private toastR: ToastrService
  ) {}
  model: any = {};


  availableColors: any[] = [
    { name: 'None', color: undefined },
    { name: 'Primary', color: 'primary' },
    { name: 'Accent', color: 'accent' },
    { name: 'Warn', color: 'warn' }
  ];

  baseUrl: string = 'https://localhost:7004/api/';

  bookingWithoutLogin: any = {};

  isMassageSelected: boolean = false;
  isDateSelected: boolean = false;
  isFormFilled: boolean = false;

  massageName: string | null = null;
  selected: Date | null = null;

  value: string = '';
  viewValue: string = '';

  hours: string[] = [
    '13:00',
    '14:00',
    '15:00',
    '16:00',
    '17:00',
    '18:00',
    '19:00',
    '20:00',
    '21:00',
  ];

  setServiceName() {
    if (this.massageName === null) {
      this.toastR.error('Proszę wybrać rodzaj masażu!');
      return;
    }

    this.bookingWithoutLogin.massageName = this.massageName;

    this.isMassageSelected = true;
  }
  setDateMassage() {
    const date = this.selected?.toLocaleDateString();

    if(date === undefined){
      this.toastR.error("Proszę wybrać dzień rezerwacji!");
      return;
    }

    this.bookingWithoutLogin.date = date;

    this.isDateSelected = true;
  }

  setGuestInformation() {
    this.bookingWithoutLogin.name = this.model.name;
    this.bookingWithoutLogin.surname = this.model.surname;
    this.bookingWithoutLogin.email = this.model.eMail;
    this.bookingWithoutLogin.phonenumber = this.model.phoneNumber;
    this.bookingWithoutLogin.city = this.model.city;

    this.bookingNewMassage();
  }

  bookingNewMassage() {
    console.log("I'm here");
    this.httpClient
      .post(this.baseUrl + 'booking', this.bookingWithoutLogin)
      .subscribe({
        next: (response) => console.log(response),
        error: (error) => console.log(error),
      });
  }
}
