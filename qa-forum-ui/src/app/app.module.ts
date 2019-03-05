import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

//External Modules
import { OAuthModule, OAuthStorage } from 'angular-oauth2-oidc';

//Core Services
import { AuthGuard } from './core/guards/auth.guard';
import { CustomHttpInterceptor } from './core/interceptor/custom.http.interceptor';

//Feature modules
import { SessionModule } from './modules/session/session.module';
import { UtilsModule } from './modules/utils/utils.module';
import { PagesModule } from './modules/pages/pages.module';
import { AuthService } from './core/services/auth.services';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    OAuthModule.forRoot(),
    AppRoutingModule,
    SessionModule,
    UtilsModule,
    NgbModule,
    PagesModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  providers: [
    AuthGuard,
    {
      provide: OAuthStorage,
      useValue: localStorage
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CustomHttpInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
