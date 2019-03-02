import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopNavComponent } from './top-nav/top-nav.component';
import { FooterComponent } from './footer/footer.component';

//Utils
import {AppRoutingModule} from '../../app-routing.module';

@NgModule({
  declarations: [TopNavComponent, FooterComponent],
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  exports:[
    TopNavComponent,
    FooterComponent
  ]
})
export class UtilsModule { }
