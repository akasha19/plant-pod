import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
import { SERVICE_URL } from '../app.module';
import { Plant } from '../plantpedia-page/plant';
import { Response } from './Response';

@Injectable({
  providedIn: 'root'
})

export class PlantsService {
  client: HttpClient;
  url: string;

  constructor(httpClient: HttpClient, @Inject(SERVICE_URL) baseUrl: string) {
    this.client = httpClient;
    this.url = `${baseUrl}plants`;
  }

  getPlants(): Observable<Response<Plant[]>> {
    return this.client.get<Plant[]>(this.url)
      .pipe(map((plants) => {
        plants.map((plant) => {
          plant.imageSource = `assets/img/${plant.shortName.replace(" ", "").toLowerCase()}.jpg`
        })
        return { success: true, data: plants }
      }))
      .pipe(catchError((error: HttpErrorResponse) => {
        console.error(`error while requesting plants, status code: ${error.status}, message: ${error.message}`);
        return of({ success: false, message: error.message });
      }));
  }
}
