import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';

@Component({
  selector: 'app-booking-without-login',
  templateUrl: './booking-without-login.component.html',
  styleUrls: ['./booking-without-login.component.css']
})

export class BookingWithoutLoginComponent {
  constructor(public accountService: AccountService){

  }
  model: any = {};

  isMassageSelected: boolean = false;
  isDateSelected: boolean = false;
  isFormFilled: boolean = false;

  serviceName = null;
  selected: Date | null = null;

  value: string ="";
  viewValue: string ="";

  hours: string[] = ['13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00'];


  showDateContainer(){
    this.isMassageSelected = true;
  }
  showNewBookingContainer(){
    this.isDateSelected = true;
  }

  addNewBooking(){
    console.log(this.model);
  }
}
