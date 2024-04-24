import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  isRegistrationPage = false;
  isQuestionnairePage = false;
  massages: any;

  constructor(private accountService: AccountService){
    this.getMassages();
  }

  getMassages(){
    this.accountService.getMassages().subscribe({
      next: response => {
        console.log(response);
        this.massages = response
      },
      error: error => console.log(error)
    })
  }

  goToRegistration() {
    this.isQuestionnairePage = false;
    this.isRegistrationPage = true;
  }
  goToQuestionnaire() {
    this.isQuestionnairePage = false;
    this.isQuestionnairePage = true;
  }
  cancelRegisterMode(event: boolean){
    this.isRegistrationPage = event;
  }
}
