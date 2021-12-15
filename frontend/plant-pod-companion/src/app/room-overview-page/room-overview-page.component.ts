import { Component, OnInit } from '@angular/core';
import { RoomData } from '../types/RoomData';
@Component({
  selector: 'app-room-overview-page',
  templateUrl: './room-overview-page.component.html',
  styleUrls: ['./room-overview-page.component.scss']
})

export class RoomOverviewPageComponent implements OnInit {

  Rooms: RoomData[] | undefined;
  readonly maxTemperatureWarn = "(Maximum Temperature) The temperature of this room it too warm which can cause fatigue and headaches, please open the window for some fresh air.";
  readonly minTemperatureWarn = "(Minimum Temperature) The temperature of this room it too cold which can cause discomfort and a higher chance of sickness, please turn on the heater to heat up the room.";

  ngOnInit(): void {
    this.Rooms = [
      {
        id: "1",
        sensorId: "1",
        name: "Room 1 | presentation room",
        description: "presentation room for 100 people",
        facilities: ['Airconditioning', 'heating', 'smartprojector', 'smartplants'],
        imageSource: "assets/img/room_1.jpg"
      },
      {
        id: "2",
        sensorId: "2",
        name: "Room 2 | meeting room",
        description: "meeting room for 8 people",
        facilities: ['Airconditioning', 'heating', 'smartboard', 'smartplants'],
        imageSource: "assets/img/room_2.jpg"
      },

    ]
  }





}
