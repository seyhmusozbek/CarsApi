import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public baskets: Basket[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log(baseUrl);
    http.get<Basket[]>(baseUrl + 'api/Basket').subscribe(result => {
      this.baskets = result;
      console.log(this.baskets);
    }, error => console.error(error));
  }
}

interface Basket {
  carId: number;
  quantity: number;
  price: number;
  id: number;
  addedBy: string;
  addedOn: Date;
  modifiedBy: string;
  modifiedOn: Date;
}
