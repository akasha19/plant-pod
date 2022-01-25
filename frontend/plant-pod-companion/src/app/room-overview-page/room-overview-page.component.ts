import { Component, OnInit } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { RoomsService } from '../services/rooms.service';
import { OverviewType } from '../types/OverviewType';
import { RequestError } from '../types/RequestError';
import { Room } from '../types/Room';

@Component({
  selector: 'app-room-overview-page',
  templateUrl: './room-overview-page.component.html',
  styleUrls: ['./room-overview-page.component.scss']
})

export class RoomOverviewPageComponent implements OnInit {

  rooms$: Observable<Room[]> | undefined;
  error: RequestError = { hasError: false };

  readonly overviewType: string = OverviewType.All.toString()

  constructor(private roomsService: RoomsService) { }

  ngOnInit(): void {
    this.roomsService.getRooms()
      .pipe(map((value) => {
        if (value.success && value.data) {
          this.rooms$ = of(value.data)
        } else {
          this.error = { hasError: true, message: value.message };
        }
      })).subscribe();
  }
}
