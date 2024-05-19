import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {

  title = 'stepperTwo';

  hour: string = "";

  availableHours: any=[
    {hour: '10:00'},
    {hour: '11:00'},
    {hour: '12:00'},
    {hour: '13:00'},
    {hour: '14:00'},
    {hour: '15:00'},
    {hour: '16:00'},
    {hour: '17:00'},
  ]
}
