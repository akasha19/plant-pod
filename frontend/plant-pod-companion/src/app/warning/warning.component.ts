import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LiveDataService } from '../services/live-data.service';
import { Sensor } from '../types/Sensor';

@Component({
  selector: 'warning-module',
  templateUrl: './warning.component.html',
  styleUrls: ['./warning.component.scss']
})
export class WarningComponent implements OnInit {

  @Input()
  roomNames: { [id: string]: string } | undefined;

  sensors$: Observable<Sensor[]> | undefined;

  constructor(private liveDataService: LiveDataService) { }

  ngOnInit(): void {
    this.sensors$ = this.liveDataService.sensorData$.asObservable()
  }
}
