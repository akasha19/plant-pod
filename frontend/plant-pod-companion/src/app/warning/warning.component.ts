import { Component, OnInit } from '@angular/core';
import { Sensor } from '../types/Sensor';

@Component({
  selector: 'warning-module',
  templateUrl: './warning.component.html',
  styleUrls: ['./warning.component.scss']
})
export class WarningComponent implements OnInit {

  sensors: Sensor[] | undefined;
  roomNames: {[id: string]: string}={}

  constructor() {
    this.roomNames["1"]="living room",
    this.roomNames["2"]="bedroom"
   }

  ngOnInit(): void {

    this.sensors = [{
      id: "1",
      humidity: 52,
      ph: 5,
      temperature: 17,
      moisture: "Wet",
    },
    {
      id: "2",
      humidity: 49,
      ph: 7,
      temperature: 30,
      moisture: "Dry",
    }
  ]
  }
}
