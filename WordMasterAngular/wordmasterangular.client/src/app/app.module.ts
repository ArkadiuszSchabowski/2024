import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { AddFlashCardComponent } from './add-flash-card/add-flash-card.component';
import { RemoveFlashCardComponent } from './remove-flash-card/remove-flash-card.component';
import { DisplayFlashCardComponent } from './display-flash-card/display-flash-card.component';
import { UpdateFlashCardComponent } from './update-flash-card/update-flash-card.component';
import { FlashCardUpdateComponent } from './flash-card-update/flash-card-update.component';
import { FlashCardRemoveComponent } from './flash-card-remove/flash-card-remove.component';
import { FlashCardAddComponent } from './flash-card-add/flash-card-add.component';
import { FlashCardDisplayComponent } from './flash-card-display/flash-card-display.component';
import { TestComponent } from './test/test.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidenavComponent,
    LoginComponent,
    RegistrationComponent,
    AddFlashCardComponent,
    RemoveFlashCardComponent,
    DisplayFlashCardComponent,
    UpdateFlashCardComponent,
    FlashCardUpdateComponent,
    FlashCardRemoveComponent,
    FlashCardAddComponent,
    FlashCardDisplayComponent,
    TestComponent
  ],
  imports: [
    BrowserModule, HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
