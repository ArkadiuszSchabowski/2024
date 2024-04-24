import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  @Output() cancelRegister = new EventEmitter();

  model: any ={};

  registerUser(){
    console.log(this.model)
  }
  cancel(){
    this.cancelRegister.emit(false);
  }
}
