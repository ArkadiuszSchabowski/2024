import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomePageComponent } from './home-page/home-page.component';
import { BookingComponent } from './booking/booking.component';
import { OfferComponent } from './offer/offer.component';
import { ContactComponent } from './contact/contact.component';
import { ClientPanelComponent } from './client-panel/client-panel.component';
import { authGuard } from './_guards/auth.guard';
import { withoutAuthGuard } from './_guards/without-auth.guard';
import { BookingWithoutLoginComponent } from './booking-without-login/booking-without-login.component';

const routes: Routes = [
  {path: "", component: HomePageComponent},
  {path: "login", component: LoginComponent, canActivate: [withoutAuthGuard]},
  {path: "register", component: RegisterComponent, canActivate: [withoutAuthGuard]},
  {path: "booking", component: BookingComponent},
  {path: "booking/without-login", component: BookingWithoutLoginComponent},
  {path: "massages", component: OfferComponent},
  {path: "contact", component: ContactComponent},
  {path: "client-panel", component: ClientPanelComponent, canActivate: [authGuard]},
  {path: "**", component: HomePageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }