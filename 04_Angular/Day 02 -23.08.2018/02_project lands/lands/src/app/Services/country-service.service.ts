import { Injectable } from '@angular/core';
import{country} from '../Models/country'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, filter, catchError, mergeMap } from 'rxjs/operators';







@Injectable({
  providedIn: 'root'
})
export class CountryServiceService {

  constructor(private http: HttpClient) { }

  url:string='https://restcountries.eu/rest/v2/all';


  getCountryList(): Observable<any>{
  return  this.http.get('https://restcountries.eu/rest/v2/all?fields=name;nativeName;capital;population;flag');
  }

 

}
