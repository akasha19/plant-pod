import { Component, OnInit } from '@angular/core';
import { room } from '../types/Room';
@Component({
  selector: 'app-room-overview-page',
  templateUrl: './room-overview-page.component.html',
  styleUrls: ['./room-overview-page.component.scss']
})

export class RoomOverviewPageComponent implements OnInit {

  Rooms: room[] | undefined;


  ngOnInit(): void {
    this.Rooms = [
      {
        id: "1",
        sensorId: "1",
        name: "Presentation room",
        description: "presentation room for 100 people",
        facilities: ['Airconditioning', 'heating', 'smartprojector', 'smartplants'],
        imageSource: "assets/img/room_1.jpg"
      },
      {
        id: "2",
        sensorId: "2",
        name: "Meeting room",
        description: "meeting room for 8 people",
        facilities: ['Airconditioning', 'heating', 'smartboard', 'smartplants'],
        imageSource: "assets/img/room_2.jpg"
      },
    ]
  }
}
