import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../_service/account.service';
import { inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';

export const withoutAuthGuard: CanActivateFn = (route, state) => {

  const accountService = inject(AccountService);
  const toastr = inject(ToastrService);
  const router = inject(Router)

  return accountService.currentUser$.pipe(
    map((user) => {
      if (user) {
        router.navigateByUrl("/");
        toastr.error('Wyloguj się, by przejść do rejestracji lub logowania!');
        return false;
      }
      else return true;
    })
  );
};
