import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  constructor(private router: Router) {

  }
  massages(){
    this.router.navigateByUrl("/massages");
  }
}