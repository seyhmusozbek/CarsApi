import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public baskets: Basket[];
  length = 0;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<Basket[]>(baseUrl + 'api/Basket').subscribe(result => {
      this.baskets = result;
      this.length = this.baskets.length;
    }, error => console.error(error));
  }
  deleteRow(index: number, id: number) {
    const httpParams = new HttpParams().set('id', id.toString());
    const options = {params: httpParams};
    this.http.delete(this.baseUrl + 'api/Basket', options).subscribe(result => {
      if (result > 0) {
        this.baskets.splice(index, 1);
      }
    });
  }
}
