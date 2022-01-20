import { Component, OnInit } from '@angular/core';
import { Room } from "../types/Room";
import { RoomsService } from '../services/rooms.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-room-details-page',
  templateUrl: './room-details-page.component.html',
  styleUrls: ['./room-details-page.component.scss']
})
export class RoomDetailsPageComponent implements OnInit {

  room: Room | undefined;
  rooms: Observable<Room[] | undefined> | undefined;

  constructor(roomsService: RoomsService) {
    this.rooms = roomsService.getRooms();
  }

  ngOnInit(): void {

    this.room =
    {
      id: "1",
      sensorId: "1",
      name: "Living Room",
      description: "A Living Room on the first floor of the house",
      facilities: ["Airconditioning", "Heating", "Humidifier"],
      imageSource: "../assets/img/aloevera.jpg"
    }
  }
}
