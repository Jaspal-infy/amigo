import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ChangePassComponent } from './change-pass/change-pass.component';
import { HttpClientModule } from '@angular/common/http';
import { routing } from '../app.routing';
import { ForgotpassComponent } from './forgotpass/forgotpass.component';

@NgModule({
  declarations: [
    AppComponent,
    ChangePassComponent,
    ForgotpassComponent
  ],
  imports: [
    BrowserModule,
    routing,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
