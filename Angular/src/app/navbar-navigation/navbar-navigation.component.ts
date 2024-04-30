import { Component } from '@angular/core';
import { AccountService } from '../_service/account.service';

@Component({
  selector: 'app-navbar-navigation',
  templateUrl: './navbar-navigation.component.html',
  styleUrls: ['./navbar-navigation.component.css']
})
export class NavbarNavigationComponent {
  constructor(public accountService: AccountService){

  }
}
