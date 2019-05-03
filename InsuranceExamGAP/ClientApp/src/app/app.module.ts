import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LayoutModule } from '@angular/cdk/layout';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { MaterialModule } from './material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { AlertComponent } from './_shared';
import { PolicyComponent } from './policy';
import { PolicyClientComponent } from './policyClient';
import { DialogPolicyFormComponent } from './dialogPolicyForm';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { HeaderComponent } from './header';
import { FooterComponent } from './footer';

import { JwtInterceptor, ErrorInterceptor} from "./_helpers";

@NgModule({

  entryComponents: [
    PolicyComponent,
    DialogPolicyFormComponent
  ],
  declarations: [
    AppComponent,
    AlertComponent,
    PolicyComponent,
    LoginComponent,
    RegisterComponent,
    HeaderComponent,
    FooterComponent,
    DialogPolicyFormComponent,
    PolicyClientComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    MaterialModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    LayoutModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
