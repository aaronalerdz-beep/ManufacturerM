import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { BusyServices } from '../services/busy.service';
import { delay, finalize } from 'rxjs';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
   const busyService = inject(BusyServices)

  busyService.busy();

  return next(req).pipe(
    delay(500),
    finalize(() =>  busyService.idle())
  );
};
