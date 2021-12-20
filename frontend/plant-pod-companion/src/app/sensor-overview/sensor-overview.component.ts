import { Component, Input, OnInit } from '@angular/core';
import { Sensor } from '../types/Sensor';

@Component({
  selector: 'sensor-overview',
  templateUrl: './sensor-overview.component.html',
  styleUrls: ['./sensor-overview.component.scss']
})
export class SensorOverviewComponent implements OnInit {

  @Input()
  id: string | undefined;

  sensor: Sensor | undefined;

  constructor() { }

  ngOnInit(): void {

    this.sensor = {
      id: this.id ?? "",
      humidity: 2,
      ph: 5,
      temperature: 8,
      moisture: 4,
    }

  }


}
