import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { SERVICE_URL } from '../app.module';
import { Room } from '../types/Room';

@Injectable({
  providedIn: 'root'
})
export class RoomsService {
  client: HttpClient;
  url: string;

  constructor(httpClient: HttpClient, @Inject(SERVICE_URL) baseUrl: string) {
    this.client = httpClient;
    this.url = `${baseUrl}rooms`;
  }

  getRooms(): Observable<Room[] | undefined> {
    return this.client.get<Room[]>(this.url)
      .pipe(catchError((error: HttpErrorResponse) => {
        console.error(`error while requesting rooms, status code: ${error.status}, message: ${error.message}`);
        return of(undefined);
      }));
  }

  getRoomById(id: string): Observable<Room | undefined> {
    return this.client.get<Room>(`${this.url}/${id}`)
      //debug
      .pipe(tap((value) => console.log(value)))
      .pipe(catchError((error: HttpErrorResponse) => {
        console.error(`error while requesting rooms, status code: ${error.status}, message: ${error.message}`);
        return of(undefined);
      }));
  }
}
