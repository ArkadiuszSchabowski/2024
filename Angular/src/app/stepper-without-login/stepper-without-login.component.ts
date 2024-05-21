import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { CreateBookingDto } from '../_models/createBookingDto';

@Component({
  selector: 'app-stepper-without-login',
  templateUrl: './stepper-without-login.component.html',
  styleUrls: ['./stepper-without-login.component.css']
})
export class StepperWithoutLoginComponent {
  constructor(public accountService: AccountService, private httpClient: HttpClient, private toastR: ToastrService
  ) {}

  baseUrl: string = 'https://localhost:7004/api/';

  newBooking: CreateBookingDto = new CreateBookingDto();

  isMassageTypeSelected: boolean = false;
  isDateSelected: boolean = false;
  isHourSelected: boolean = false;

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
    if (this.newBooking.massageName === null) {
      this.toastR.error('Proszę wybrać rodzaj masażu!');
      return;
    }
    this.isMassageTypeSelected = true;

  }
  setDateMassage() {
    const date = this.selected?.toLocaleDateString();

    if(date === undefined){
      this.toastR.error("Proszę wybrać dzień rezerwacji!");
      return;
    }

    this.newBooking.date = date;

    this.isDateSelected = true;

  }

  setHourMassage(){
    if(this.newBooking.hour === null || this.newBooking.hour === undefined){
      this.toastR.error("Proszę wybrać godzinę rezerwacji!");
      return;
    }
    this.isHourSelected = true;
  }

  setGuestInformation() {

    this.bookingNewMassage();
  }

  bookingNewMassage() {
    console.log(this.newBooking);
    this.httpClient
      .post(this.baseUrl + 'booking', this.newBooking)
      .subscribe({
        next: (response) => console.log(response),
        error: (error) => console.log(error),
      });
  }
}
