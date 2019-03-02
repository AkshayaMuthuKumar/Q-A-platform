import { CanActivate, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { AuthService } from '../services/auth.services';
import { Observable } from 'rxjs';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService,
        private router: Router) {

    }
    canActivate(): boolean | Observable<boolean> {
        if (this.authService.hasValidIdToken()) {
            return true;
        }
        // not logged in so redirect to login
        this.router.navigate(['/login']);
        return false;
    }
}
