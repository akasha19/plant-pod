import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { SERVICE_URL } from '../app.module';
import { Sensor } from '../types/Sensor';
import * as signalR from "@microsoft/signalr";

@Injectable({
  providedIn: 'root'
})
export class LiveDataService {
  client: HttpClient;
  url: string;
  evententData: Sensor | undefined;

  constructor(httpClient: HttpClient, @Inject(SERVICE_URL) baseUrl: string) {
    this.client = httpClient;
    this.url = `${baseUrl}LiveDataHub`;

    const connection = new signalR.HubConnectionBuilder()
      .withUrl(this.url, {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();

    connection.on("ReceiveMessage", (message: string) => {
      console.log(message)
    });

    connection.start().catch(err => document.write(err));
  }


}
