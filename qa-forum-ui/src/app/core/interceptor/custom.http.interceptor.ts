import { Injectable, Injector } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { AuthService } from '../services/auth.services';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor {
    constructor(private injector: Injector) { }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const auth = this.injector.get(AuthService);
        console.log(request);
        if (auth && request.url != 'https://www.googleapis.com/oauth2/v3/certs') {
            console.log(auth.email);
            request = request.clone({
                setHeaders: {
                    'Authorization': `Bearer ${auth.getAccessToken()}`,
                    'x-email':`${auth.email}`
                }
            });
        }
        return next.handle(request);
    }
}