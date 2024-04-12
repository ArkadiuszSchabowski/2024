import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { FlashCardUpdateComponent } from './flash-card-update/flash-card-update.component';
import { FlashCardRemoveComponent } from './flash-card-remove/flash-card-remove.component';
import { FlashCardAddComponent } from './flash-card-add/flash-card-add.component';
import { FlashCardDisplayComponent } from './flash-card-display/flash-card-display.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    RegistrationComponent,
    FlashCardUpdateComponent,
    FlashCardRemoveComponent,
    FlashCardAddComponent,
    FlashCardDisplayComponent,
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    MatToolbarModule,
    MatSidenavModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
