import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: '', 
  runGuardsAndResolvers: 'always',
  canActivate: [authGuard],
  children: [
    { path: 'members', component: MemberListComponent},
    { path: 'members/:id', component: MemberDetailComponent },
    { path: 'lists', component: ListsComponent },
    { path: 'messages', component: MessagesComponent },
  ]
},
  { path: '**', component: HomePageComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
