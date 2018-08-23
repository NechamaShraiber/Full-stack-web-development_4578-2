import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { HomeComponent } from './Components/home/home.component';
import { MenuComponent } from './Components/menu/menu.component';
import { CountriesListComponent } from './Components/countries-list/countries-list.component';
import { Routes, RouterModule } from "@angular/router";
import { CountryServiceService } from './Services/country-service.service';
import {  JsonpModule } from '@angular/http';
// import{Ng2SearchPipeModule}from 'ng2-search-filter'
const route: Routes = [
   { path: 'lands/home', component: HomeComponent },
   { path: 'lands/listCountries', component: CountriesListComponent },
   
   { path:'**', redirectTo:'lands/home' },

 ]


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    CountriesListComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(route),
    BrowserModule,
    FormsModule,
    HttpClientModule,
    JsonpModule,
    // Ng2SearchPipeModule

  ],
  providers: [
    CountryServiceService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
