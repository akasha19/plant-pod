import { Component, OnInit } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { LiveDataService } from '../services/live-data.service';
import { RoomsService } from '../services/rooms.service';
import { Sensor } from '../types/Sensor';

@Component({
  selector: 'warning-module',
  templateUrl: './warning.component.html',
  styleUrls: ['./warning.component.scss']
})
export class WarningComponent implements OnInit {

  roomNames$: Observable<{ [id: string]: string } | undefined> | undefined;

  sensors$: Observable<Sensor[]> | undefined;

  constructor(
    private liveDataService: LiveDataService,
    private roomsService: RoomsService
  ) { }

  ngOnInit(): void {
    this.sensors$ = this.liveDataService.sensorData$.asObservable()

    this.roomsService.getRooms()
      .pipe(map((value) => {
        if (value.success && value.data) {
          let names: { [id: string]: string } = {};
          value.data.forEach((room) => {
            names[room.sensorId] = room.name;
          });
          this.roomNames$ = of(names);
        } else {
          console.log("error while requesting rooms: ", value.message)
        }
      })).subscribe();
  }
}
