import { Component, OnInit } from '@angular/core';
import { Room } from '../types/Room';
import { Sensor} from '../types/Sensor';

@Component({
  selector: 'app-room-overview-page',
  templateUrl: './room-overview-page.component.html',
  styleUrls: ['./room-overview-page.component.scss']
})

export class RoomOverviewPageComponent {

  rooms: Room[] | undefined;

  sensor : Sensor;


  constructor() {
    this.rooms = [
      {
        id: "1",
        sensorId: "1",
        name: "Presentation room",
        description: "presentation room for 100 people",
        facilities: ['Airconditioning', 'heating', 'smartprojector', 'smartplants'],
        imageSource: "assets/img/room_1.jpg"
      }
    ]

    this.sensor =
   {
     id: "1",
     ph: 7.0,
     moisture: 50,
     temperature: 20,
    humidity: 94.3,
    airquality: "good"

   }

  }
}
