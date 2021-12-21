import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { catchError, map, Observable, of, switchMap } from 'rxjs';
import { SERVICE_URL } from '../app.module';
import { Plant } from '../plantpedia-page/plant';

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

  getPlants(): Observable<Plant[] | undefined> {
    return this.client.get<Plant[]>(this.url)
      .pipe(catchError((error: HttpErrorResponse) => {
        console.error(`error while requesting plants, status code: ${error.status}, message: ${error.message}`);
        return of(undefined);
      }));
  }
}

export interface Success<T> {
  data: T | string
}

export interface Failure {
  status: number,
  message: string
}

