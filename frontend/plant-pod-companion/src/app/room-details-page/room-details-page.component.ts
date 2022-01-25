import { Component, OnInit } from '@angular/core';
import { Sensor } from "../types/Sensor";
import { Room } from "../types/Room";

@Component({
  selector: 'app-room-details-page',
  templateUrl: './room-details-page.component.html',
  styleUrls: ['./room-details-page.component.scss']
})
export class RoomDetailsPageComponent implements OnInit {

  room: Room | undefined;

  ngOnInit(): void {
    this.room =
    {
      id: "1",
      sensorId: "196db225-e5ef-4636-b967-c214a0ddb73f",
      roomName: "Living Room",
      shortDescription: "A Living Room on the first floor of the house",
      facilities: ["Airconditioning", "Heating", "Humidifier"],
      imageSource: "../assets/img/aloevera.jpg"
    }
  }
}
