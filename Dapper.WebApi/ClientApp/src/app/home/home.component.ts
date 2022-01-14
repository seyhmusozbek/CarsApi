import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public cars: Car[];
  isLoading = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    console.log('base url', baseUrl);
    http.get<Car[]>(baseUrl + 'api/Car').subscribe(result => {
      this.cars = result;
    }, error => console.error(error));
  }

  updateCar(car: Car, isLight: boolean) {
    this.isLoading = true;
    if (isLight) {
    car.isLightOn = !car.isLightOn;
    } else {
    car.isDoorOn = !car.isDoorOn;
    }
    car.modifiedBy = 'Seyhmus';
    this.http.put(this.baseUrl + 'api/Car', car).subscribe(result => {
      console.log('affected rows', result);
      this.isLoading = false;
    });
  }

  addToBasket(car: Car) {
    this.isLoading = true;
    const newBasket: Basket = {
      addedBy: 'Seyhmus',
      carId: car.id,
      price: car.price,
      quantity: 1,
      addedOn: null,
      id: null,
      modifiedBy: null,
      modifiedOn: null,
      description: car.brand + '-' + car.model
    };

    this.http.post(this.baseUrl + 'api/Basket', newBasket).subscribe(result => {
      console.log('affected rows', result);
      this.isLoading = false;
    });
  }

}



