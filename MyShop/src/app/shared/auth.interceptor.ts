import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, throwError } from "rxjs";
import { AuthService } from "./auth.service";
import { Router } from "@angular/router";

@Injectable()
export class AuthInterceptor implements HttpInterceptor{
    constructor(
        private auth: AuthService,
        private router: Router,
    ) {}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(this.auth.isAuthenticated()) {
            req = req.clone({
                setParams: {
                    auth: this.auth.token
                }
            })
        }

        return next.handle(req)
        .pipe(
            catchError(error => {
                if(error.status === 401) {
                    this.auth.logout()
                    this.router.navigate(['/admin', 'login'])
                }
                return throwError(error);
            })
        )
    }

}