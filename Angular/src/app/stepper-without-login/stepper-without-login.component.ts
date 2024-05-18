import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-stepper-without-login',
  templateUrl: './stepper-without-login.component.html',
  styleUrls: ['./stepper-without-login.component.css']
})
export class StepperWithoutLoginComponent {
  formGroup: FormGroup = new FormGroup({});
}
