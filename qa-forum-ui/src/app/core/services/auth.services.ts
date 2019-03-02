import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { AuthConfig, OAuthService} from 'angular-oauth2-oidc';


export const authConfig: AuthConfig = {
  // Url of the Identity Provider
  issuer: 'https://accounts.google.com',

  // URL of the SPA to redirect the user to after login
  redirectUri: window.location.origin,

  // The SPA's id. The SPA is registerd with this id at the auth-server
  clientId: '1002640285073-c8gejnl0sauq1gtsklr0p237n11av54c.apps.googleusercontent.com',

  strictDiscoveryDocumentValidation: false,

  // set the scope for the permissions the client should request
  // The first three are defined by OIDC. The 4th is a usecase-specific one
  scope: 'openid profile email',

  showDebugInformation: true,
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private oauthService: OAuthService,
    private router: Router) {
    this.oauthService.configure(authConfig);
    this.oauthService.loadDiscoveryDocumentAndTryLogin({
      onTokenReceived: (info) => {
        if (info.state) this.router.navigate([info.state]);
      }
    }).then(
      info => this.router.initialNavigation()
    );
  }

  public tryLogin() {
    this.oauthService.tryLogin();
  }

  public login() {
    this.oauthService.initImplicitFlow();
  }

  public logoff() {
    this.oauthService.logOut();
  }

  public hasValidIdToken() {
    return this.oauthService.hasValidIdToken()
  }

  public getAccessToken() {
    return this.oauthService.getAccessToken();
  }

  public get email() {
    let claims = this.oauthService.getIdentityClaims();
    if (!claims) {
      return null;
    }
    return claims['email'];
  }

  public get name() {
    let claims = this.oauthService.getIdentityClaims();
    if (!claims) {
      return null;
    }
    return claims['given_name'];
  }
}
