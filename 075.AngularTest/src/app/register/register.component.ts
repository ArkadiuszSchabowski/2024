import { Component } from '@angular/core';
import { registerUserDto } from '../_models/registerUserDto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  model: any ={};

  registerUser(){
    console.log(this.model)
  }
  cancel(){
    console.log("canceled");
  }
}
