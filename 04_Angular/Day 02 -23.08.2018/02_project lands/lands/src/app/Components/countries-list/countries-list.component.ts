import { Component, OnInit } from '@angular/core';
import { country } from '../../Models/country'
import { CountryServiceService } from '../../Services/country-service.service'

import{filter}from 'rxjs/operators'
@Component({
  selector: 'app-countries-list',
  templateUrl: './countries-list.component.html',
  styleUrls: ['./countries-list.component.css']
})
export class CountriesListComponent implements OnInit {

  constructor(private countryService: CountryServiceService) {
    this.newCountry = new country();
    this.countriesList = [];
  }
  newCountry: country;
  countriesList: country[];
  stringFilter:string
  result:any;
  resultForFilter:any;
  ngOnInit() {
    this.countryService.getCountryList().subscribe(res => {
this.result=res;
this.resultForFilter=res;

    //   for (var country of res) {

    //     this.newCountry.name = country["name"];
    //     this.newCountry.nativeName = country["nativeName"];
    //     this.newCountry.capital = country["capital"];
    //     this.newCountry.population = country["population"];
    //     this.newCountry.flag = country["flag"];
    //     console.log(this.newCountry);
    //     this.countriesList.push(this.newCountry);
    //   }
    //   console.log(this.countriesList);
     })


  }
  
  filter()
  {
    this.resultForFilter=this.result;
    // this.resultForFilter.splice(p=>p.)
   this.resultForFilter=this.resultForFilter.filter(p=>p.name.includes(this.stringFilter)||p.capital.includes(this.stringFilter));
  }
}


