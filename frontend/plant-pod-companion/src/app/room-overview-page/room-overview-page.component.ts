import { Component, OnInit } from '@angular/core';
import { Room } from './room';
@Component({
  selector: 'app-room-overview-page',
  templateUrl: './room-overview-page.component.html',
  styleUrls: ['./room-overview-page.component.scss']
})

export class RoomOverviewPageComponent implements OnInit {

  rooms: Room[] | undefined;
  readonly maxTemperatureWarn = "(Maximum Temperature) The temperature of this room it too warm which can cause fatigue and headaches, please open the window for some fresh air.";
  readonly minTemperatureWarn = "(Minimum Temperature) The temperature of this room it too cold which can cause discomfort and a higher chance of sickness, please turn on the heater to heat up the room.";

  ngOnInit(): void {
    this.rooms = [
      {
        id: 1,
        roomName: "Room 1 | presentation room",
        shortDescription: "presentation room for 100 people",
        facilities: "Airconditioning, heating, smartprojector, smartplants",
        minHumidity: 5,
        maxHumidity: 40,
        imageSource: "assets/img/room_1.jpg"
      },
      {
        id: 2,
        roomName: "Room 2 | meeting room",
        shortDescription: "meeting room for 8 people",
        facilities: "Airconditioning, heating, smartplants",
        minHumidity: 5,
        maxHumidity: 40,
        imageSource: "assets/img/room_2.jpg"
      },
      {
        id: 3,
        roomName: "Room 3 | collaboration room",
        shortDescription: "collaboration room",
        facilities: "Airconditioning, smartboard, smartplants, coffeemachine",
        minHumidity: 5,
        maxHumidity: 40,
        imageSource: "assets/img/room_3.jpg"
      },
      {
        id: 4,
        roomName: "Room 4 | meeting room",
        shortDescription: "meeting room for 6 people ",
        facilities: "heating",
        minTemperature: 16,
        maxTemperature: 22,
        minHumidity: 5,
        maxHumidity: 40,
        imageSource: "assets/img/room_4.jpg"
      },
      {
        id: 5,
        roomName: "Room 5 | quiet flex work room",
        shortDescription: "quiet zone for 8 people",
        facilities: "Airconditioning, heating, smartplants",
        minTemperature: 16,
        maxTemperature: 22,
        minHumidity: 5,
        maxHumidity: 40,
        imageSource: "assets/img/room_5.jpg"
      },
      {
        id: 6,
        roomName: "Room 6 | collaboration room",
        shortDescription: "collaboration room for 4 people",
        facilities: "Airconditioning, heating, smartboard, smartplants",
        minTemperature: 16,
        maxTemperature: 22,
        minHumidity: 5,
        maxHumidity: 40,
        imageSource: "assets/img/room_6.jpg"
      }
    ]
  }





}
