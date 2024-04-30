import { Component } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent {
isLoginPage: boolean = true;
isRegisterPage: boolean = false;

goToLoginPage(){
  this.isRegisterPage = false;
  this.isLoginPage = true;
}
goToRegisterPage(){
  this.isRegisterPage = true;
  this.isLoginPage = false;
}
}
