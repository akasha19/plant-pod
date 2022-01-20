import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { catchError, map, Observable, of, tap } from 'rxjs';
import { SERVICE_URL } from '../app.module';
import { Room } from '../types/Room';
import { Response } from './Response'

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

  getRoomById(id: string): Observable<Response<Room>> {
    return this.client.get<Room>(`${this.url}/${id}`)
      .pipe(map((value: Room) => {
        return { success: true, data: value }
      }))
      .pipe(catchError((error: HttpErrorResponse) => {
        console.error(`error while requesting room, status code: ${error.status}, message: ${error.message}`);
        return of({ success: false, message: error.message });
      }));
  }
}
