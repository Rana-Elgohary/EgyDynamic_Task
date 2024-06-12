import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const noNavigateToLoginPageIfTokenGuard: CanActivateFn = (route, state) => {
  let t = localStorage.getItem("token")
  if(t != null){
    const router = inject(Router);
    router.navigateByUrl('/CustomerList');
    return false;
  }
  return true
};
