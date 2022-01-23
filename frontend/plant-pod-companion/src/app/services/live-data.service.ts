import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { SERVICE_URL } from '../app.module';
import { Sensor } from '../types/Sensor';

@Injectable({
  providedIn: 'root'
})
export class LiveDataService {
  client: HttpClient;
  url: string;
  eventSource: EventSource;

  eventData: Sensor | undefined;

  constructor(httpClient: HttpClient, @Inject(SERVICE_URL) baseUrl: string) {
    this.client = httpClient;
    this.url = `${baseUrl}sse`;

    this.eventSource = new EventSource(this.url);

    this.eventSource.addEventListener("event name", (e) => {
      const event = (e as MessageEvent);  // <== This line is Important!!
      this.eventData = JSON.parse(event.data);
      console.log(this.eventData);
    });
  }
}
