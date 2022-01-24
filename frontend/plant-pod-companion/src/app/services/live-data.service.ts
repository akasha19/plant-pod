import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { WebsocketBuilder } from 'websocket-ts/lib';
import { SERVICE_URL } from '../app.module';
import { Sensor } from '../types/Sensor';

@Injectable({
  providedIn: 'root'
})
export class LiveDataService {
  client: HttpClient;
  url: string;
  evententData: Sensor | undefined;

  constructor(httpClient: HttpClient, @Inject(SERVICE_URL) baseUrl: string) {
    this.client = httpClient;
    this.url = `${baseUrl.replace("http", "ws")}livedata`;

    const ws = new WebsocketBuilder(this.url)
      .onOpen((_, event) => { console.log("opened") })
      .onClose((_, event) => { console.log("closed") })
      .onError((_, event) => { console.error(`websocket error: ${event}`) })
      .onMessage((_, event) => { this.onMessage(event.data) })
      .build();

    ws.send("test")
  }

  onMessage(data: string): void {
    let jsonObject: any = JSON.parse(data);
    let sensor: Sensor = <Sensor>jsonObject;
    console.log(sensor.id)
  }
}
