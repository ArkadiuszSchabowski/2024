import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-stepper-without-login',
  templateUrl: './stepper-without-login.component.html',
  styleUrls: ['./stepper-without-login.component.css']
})
export class StepperWithoutLoginComponent {
  constructor(public accountService: AccountService, private httpClient: HttpClient, private toastR: ToastrService
  ) {}
  model: any = {};

  baseUrl: string = 'https://localhost:7004/api/';

  bookingWithoutLogin: any = {};

  isMassageTypeSelected: boolean = false;
  isDateSelected: boolean = false;
  isHourSelected: boolean = false;

  selectedHour: string | null = null;

  massageName: string | null = null;
  selected: Date | null = null;
  completed: boolean = false;

  value: string = '';
  viewValue: string = '';

  availableHours: string[] = [
    '13:00',
    '14:00',
    '15:00',
    '16:00',
    '17:00',
    '18:00',
    '19:00',
    '20:00'
  ];

  setServiceName() {
    if (this.massageName === null) {
      this.toastR.error('Proszę wybrać rodzaj masażu!');
      return;
    }

    this.bookingWithoutLogin.massageName = this.massageName;
    this.isMassageTypeSelected = true;

  }
  setDateMassage() {
    const date = this.selected?.toLocaleDateString();
    console.log(date);

    if(date === undefined){
      this.toastR.error("Proszę wybrać dzień rezerwacji!");
      return;
    }

    this.bookingWithoutLogin.date = date;
    this.isDateSelected = true;

  }

  setHourMassage(){
    console.log(this.selectedHour);
    if(this.selectedHour=== null || this.selectedHour === undefined){
      this.toastR.error("Proszę wybrać godzinę rezerwacji!");
      return;
    }
    console.log();
    this.isHourSelected = true;
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
