import { Component, OnInit } from '@angular/core';
import { Room } from "../types/Room";
import { RoomsService } from '../services/rooms.service';
import { map, Observable, of } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { RequestError } from '../types/RequestError';
import { OverviewType } from '../types/OverviewType';

@Component({
  selector: 'app-room-details-page',
  templateUrl: './room-details-page.component.html',
  styleUrls: ['./room-details-page.component.scss']
})

export class RoomDetailsPageComponent implements OnInit {

  id: string | undefined;
  room$: Observable<Room> | undefined;
  error: RequestError = { hasError: false };

  readonly overviewType: string = OverviewType.Room.toString()

  constructor(
    private route: ActivatedRoute,
    private roomsService: RoomsService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      if (this.id) {
        this.roomsService.getRoomById(this.id)
          .pipe(map((value) => {
            if (value.success && value.data) {
              this.room$ = of(value.data)
            } else {
              this.error = { hasError: true, message: value.message };
            }
          })).subscribe();
      }
    });
  }
}
