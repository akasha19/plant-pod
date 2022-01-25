import { Component, Input, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { LiveDataService } from '../services/live-data.service';
import { Sensor } from '../types/Sensor';

@Component({
  selector: 'sensor-overview',
  templateUrl: './sensor-overview.component.html',
  styleUrls: ['./sensor-overview.component.scss']
})

export class SensorOverviewComponent {

  @Input()
  id: string | undefined;

  @Input()
  overviewType: string | undefined;

  sensor$: Observable<Sensor | undefined>;

  constructor(liveDataService: LiveDataService) {
    this.sensor$ = liveDataService.sensorData$.asObservable()
      .pipe(map((sensors) => {
        return sensors.find(s => s.id === this.id)
      }))
  }
}
