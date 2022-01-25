import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { SERVICE_URL } from '../app.module';
import { Sensor } from '../types/Sensor';
import * as signalR from "@microsoft/signalr";
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LiveDataService {
  client: HttpClient;
  url: string;
  sensorData$: BehaviorSubject<Sensor[]>;

  constructor(httpClient: HttpClient, @Inject(SERVICE_URL) baseUrl: string) {
    this.client = httpClient;
    this.url = `${baseUrl}LiveDataHub`;

    const connection = new signalR.HubConnectionBuilder()
      .withUrl(this.url, {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();

    connection.on("SensorData", (message: string) => {
      this.onNewSensorData(message)
    });

    connection.start().catch(err => console.error(err));

    this.sensorData$ = new BehaviorSubject(new Array<Sensor>())
  }

  onNewSensorData(data: string): void {
    let sensors: Sensor[] = JSON.parse(data);

    this.sensorData$?.next(sensors);
  }
}
