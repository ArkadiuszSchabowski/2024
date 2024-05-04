import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../_service/account.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent {

  isSelectedOptionVisible = true;
  model: any = {};

  constructor(private router: Router, public accountService: AccountService){

  }

  login(){
    this.router.navigateByUrl("/login");
  }
  bookingWithoutLogin(){
    this.isSelectedOptionVisible = false;
  }
  addNewBooking(){
    console.log(this.model);
  }
}
