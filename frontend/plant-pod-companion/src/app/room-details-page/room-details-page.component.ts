import { Component, OnInit } from '@angular/core';
import { Sensor } from "../types/Sensor";
import { RoomData } from "../types/RoomData";

@Component({
  selector: 'app-room-details-page',
  templateUrl: './room-details-page.component.html',
  styleUrls: ['./room-details-page.component.scss']
})
export class RoomDetailsPageComponent implements OnInit {

  room: RoomData | undefined;
  sensor: Sensor | undefined;

  constructor() { }

  ngOnInit(): void {
    this.room=
      {
        id:"1",
        sensorId: "1",
        roomName: "Living Room",
        shortDescription: "A Living Room on the first floor of the house",
        facilities:["Airconditioning","Heating","Humidifier"],
        imageSource:"../assets/img/aloevera.jpg"

      }

    this.sensor=
      {
        id: "1",
        humidity: 50,
        ph: 6.5,
        temperature: 15,
        moisture: 10

      }

  }

}
