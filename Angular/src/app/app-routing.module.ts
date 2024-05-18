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
import { StepperWithoutLoginComponent } from './stepper-without-login/stepper-without-login.component';

const routes: Routes = [
  {path: "", component: HomePageComponent},
  {path: "login", component: LoginComponent, canActivate: [withoutAuthGuard]},
  {path: "register", component: RegisterComponent, canActivate: [withoutAuthGuard]},
  {path: "booking/guest", component: BookingComponent, canActivate: [withoutAuthGuard]},
  {path: "booking/guest/without-login", component: StepperWithoutLoginComponent, canActivate: [withoutAuthGuard]},
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
